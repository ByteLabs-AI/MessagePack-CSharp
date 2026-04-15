using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities;
using Nuke.Components;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

[DotNetVerbosityMapping]
[ShutdownDotNetAfterServerBuild]
partial class Build
    : NukeBuild,
        IHazChangelog,
        IHazGitRepository,
        //IHazGitVersion,
        IHazNerdbankGitVersioning,
        IHazSolution,
        IRestore,
        ICompile,
        IPack,
        ITest,
        IReportCoverage,
        IReportIssues,
        IReportDuplicates,
        IPublish,
        ICreateGitHubRelease
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => ((IPack)x).Pack);

    [CI] readonly TeamCity TeamCity;
    [CI] readonly AzurePipelines AzurePipelines;
    [CI] readonly AppVeyor AppVeyor;
    [CI] readonly GitHubActions GitHubActions;

    GitVersion GitVersion => From<IHazGitVersion>().Versioning;
    GitRepository GitRepository => From<IHazGitRepository>().GitRepository;

    //[Solution(GenerateProjects = true)] readonly Solution Solution;
    //Nuke.Common.ProjectModel.Solution IHazSolution.Solution => Solution;

    private Solution _solution => ((IHazSolution)this).Solution;

    IHazTwitterCredentials TwitterCredentials => From<IHazTwitterCredentials>();

    AbsolutePath OutputDirectory => RootDirectory / "buildartifacts";
    AbsolutePath SourceDirectory => RootDirectory / "srv";

    const string MasterBranch = "master";
    const string DevelopBranch = "develop";
    const string ReleaseBranchPrefix = "release";
    const string HotfixBranchPrefix = "hotfix";

    AbsolutePath IHazArtifacts.ArtifactsDirectory => OutputDirectory;

    Target Clean => _ => _
        .Before<IRestore>()
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("*/bin", "*/obj").DeleteDirectories();
            OutputDirectory.CreateOrCleanDirectory();
        });

    Configure<DotNetBuildSettings> ICompile.CompileSettings => _ => _
        .When(!ScheduledTargets.Contains(((IPublish)this).Publish), _ => _
            .ClearProperties());

    Configure<DotNetPublishSettings> ICompile.PublishSettings => _ => _
        .When(!ScheduledTargets.Contains(((IPublish)this).Publish), _ => _
            .ClearProperties());

    IEnumerable<(Nuke.Common.ProjectModel.Project Project, string Framework)> ICompile.PublishConfigurations =>
        from project in _solution.AllProjects.Where(x=>x.Name.StartsWith("MessagePack"))
        from framework in project.GetTargetFrameworks()
        select (project, framework);

    IEnumerable<Nuke.Common.ProjectModel.Project> ITest.TestProjects => Partition.GetCurrent(_solution.GetAllProjects("*.Tests"));

    [Parameter]
    public int TestDegreeOfParallelism { get; } = 1;

    Configure<DotNetTestSettings> ITest.TestSettings => _ => _
        .SetProcessEnvironmentVariable("NUKE_TELEMETRY_OPTOUT", bool.FalseString);

    Target ITest.Test => _ => _
        .Inherit<ITest>()
        .OnlyWhenStatic(() => Host is not GitHubActions { Workflow: AlphaDeployment })
        .Partition(2);

    bool IReportCoverage.CreateCoverageHtmlReport => true;
    bool IReportCoverage.ReportToCodecov => false;

    IEnumerable<(string PackageId, string Version)> IReportIssues.InspectCodePlugins
        => new (string PackageId, string Version)[]
           {
               new("ReSharperPlugin.CognitiveComplexity", ReSharperPluginLatest)
           };

    bool IReportIssues.InspectCodeFailOnWarning => false;
    bool IReportIssues.InspectCodeReportWarnings => true;
    IEnumerable<string> IReportIssues.InspectCodeFailOnIssues => new string[0];
    IEnumerable<string> IReportIssues.InspectCodeFailOnCategories => new string[0];

    Configure<DotNetPackSettings> IPack.PackSettings => _ => _
        .When(Host is Terminal or GitHubActions { Workflow: AlphaDeployment }, _ => _
            .SetVersion(DefaultDeploymentVersion));

    [Parameter] readonly string BetaArtifactsFeed;
    [Parameter] readonly string ArtifactsFeed;
    string DefaultDeploymentVersion => "9999.0.0";

    [Parameter] [Secret] readonly string PublicNuGetApiKey;
    [Parameter] [Secret] readonly string FeedzNuGetApiKey;

    bool IsPublicRelease => GitRepository.IsOnMasterBranch() || GitRepository.IsOnReleaseBranch();
    string IPublish.NuGetSource => IsPublicRelease ? ArtifactsFeed : BetaArtifactsFeed;
    string IPublish.NuGetApiKey => "az";

    Target IPublish.Publish => _ => _
        .Inherit<IPublish>()
        .Consumes(From<IPack>().Pack)
        .Requires(() => IsPublicRelease && Host is AzurePipelines)
        .WhenSkipped(DependencyBehavior.Execute);

    IEnumerable<AbsolutePath> NuGetPackageFiles
        => From<IPack>().PackagesDirectory.GlobFiles("*.nupkg");

    string ICreateGitHubRelease.Name => MajorMinorPatchVersion;
    IEnumerable<AbsolutePath> ICreateGitHubRelease.AssetFiles => NuGetPackageFiles;

    Target ICreateGitHubRelease.CreateGitHubRelease => _ => _
        .Inherit<ICreateGitHubRelease>()
        .TriggeredBy<IPublish>()
        .ProceedAfterFailure()
        .OnlyWhenStatic(() => GitRepository.IsOnMasterBranch())
        .Executes(async () =>
        {
            var issues = await GitRepository.GetGitHubMilestoneIssues(MilestoneTitle);
            foreach (var issue in issues)
                await GitHubActions.Instance.CreateComment(issue.Number, $"Released in {MilestoneTitle}! 🎉");
        });

    T From<T>()
        where T : INukeBuild
        => (T)(object)this;
}
