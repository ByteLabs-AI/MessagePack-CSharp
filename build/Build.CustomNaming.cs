using System.Collections.Generic;
using Nuke.Components;

partial class Build
{
    static Dictionary<string, string> CustomNames =
        new()
        {
            { nameof(ICompile.Compile), "⚙️" },
            { nameof(ITest.Test), "🚦" },
            { nameof(IPack.Pack), "📦" },
            { nameof(IReportCoverage.ReportCoverage), "📊" },
            { nameof(IReportDuplicates.ReportDuplicates), "🎭" },
            { nameof(IReportIssues.ReportIssues), "💣" },
            { nameof(ISignPackages.SignPackages), "🔑" },
            { nameof(IPublish.Publish), "🚚" }
        };
}
