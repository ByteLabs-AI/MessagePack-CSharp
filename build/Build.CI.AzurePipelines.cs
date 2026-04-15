using System.Collections.Generic;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Components;

[AzurePipelines(
    suffix: null,
    AzurePipelinesImage.UbuntuLatest,
    AzurePipelinesImage.WindowsLatest,
    AzurePipelinesImage.MacOsLatest,
    PullRequestsDisabled = true,
    InvokedTargets = new[] { nameof(ITest.Test), nameof(IPublish.Publish) },
    NonEntryTargets = new[] { nameof(IRestore.Restore), nameof(ICompile.Compile), nameof(IPack.Pack) },
    ExcludedTargets = new[] { nameof(Clean), nameof(ISignPackages.SignPackages) },
    CacheKeyFiles = new[] { "global.json", "src/**/*.csproj" },
    ImportVariableGroups = new[] { "GlobalVariablesLibrary" },
    FetchDepth = 0,
    EnableAccessToken = true)]
partial class Build
{
    public class AzurePipelinesAttribute : Nuke.Common.CI.AzurePipelines.AzurePipelinesAttribute
    {
        public bool NuGetAuthenticate { get; set; } = true;
        public string[]? SdkVersions { get; set; } = System.Array.Empty<string>();

        public AzurePipelinesAttribute(
            string suffix,
            AzurePipelinesImage image,
            params AzurePipelinesImage[] images)
            : base(suffix, image, images)
        {
        }

        protected override AzurePipelinesJob GetJob(
            ExecutableTarget executableTarget,
            LookupTable<ExecutableTarget, AzurePipelinesJob> jobs,
            IReadOnlyCollection<ExecutableTarget> relevantTargets,
            AzurePipelinesImage image)
        {
            var job = base.GetJob(executableTarget, jobs, relevantTargets, image);

            var symbol = CustomNames.GetValueOrDefault(job.Name);
            job.DisplayName = (job.Parallel == 0
                ? $"{symbol} {job.DisplayName}"
                : $"{symbol} {job.DisplayName} 🧩").Trim();
            return job;
        }

        protected override IEnumerable<AzurePipelinesStep> GetSteps(ExecutableTarget executableTarget, IReadOnlyCollection<ExecutableTarget> relevantTargets, AzurePipelinesImage image)
        {
            if (NuGetAuthenticate)
            {
                yield return new AzurePipelinesNuGetAuthenticateStep();
            }

            if (SdkVersions?.Length > 0)
            {
                foreach (var version in SdkVersions)
                {
                    yield return new AzurePipelinesSdkInstallStep(version);
                }
            }

            foreach (var step in base.GetSteps(executableTarget, relevantTargets, image))
            {
                yield return step;
            }
        }

    }

    public class AzurePipelinesNuGetAuthenticateStep : AzurePipelinesStep
    {
        public override void Write(CustomFileWriter writer) => writer.WriteLine("- task: NuGetAuthenticate@1");
    }

    public class AzurePipelinesSdkInstallStep : AzurePipelinesStep
    {
        public string Version { get; }

        public AzurePipelinesSdkInstallStep(string version)
        {
            Version = version;
        }

        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock("- task: UseDotNet@2"))
            {
                writer.WriteLine($"displayName: Installing SDK Version {Version}");
                using (writer.WriteBlock("inputs:"))
                {
                    writer.WriteLine("packageType: 'sdk'");
                    writer.WriteLine($"version: {Version.SingleQuote()}");
                }
            }
        }
    }
}
