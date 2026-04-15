using System.Collections.Generic;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Components;

partial class Build : ISignPackages
{
    public IEnumerable<AbsolutePath> SignPathPackages => NuGetPackageFiles;

    public Target SignPackages => _ => _
        .Inherit<ISignPackages>()
        .OnlyWhenStatic(() => IsPublicRelease)
        .OnlyWhenStatic(() => EnvironmentInfo.IsWin);
}
