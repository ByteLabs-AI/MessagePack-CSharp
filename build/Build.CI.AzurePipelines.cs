using System.Collections.Generic;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
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
    FetchDepth = 0)]
partial class Build
{
    public class AzurePipelinesAttribute : Nuke.Common.CI.AzurePipelines.AzurePipelinesAttribute
    {
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
    }
}
