# Public API

## Namespaces & Types

### Nuke.Common.CI

- BuildServerConfigurationGeneration
- BuildServerConfigurationGenerationAttributeBase
- ChainedConfigurationAttributeBase
- CIAttribute
- ConfigurationAttributeBase
- ConfigurationEntity
- GenerateBuildServerConfigurationsAttribute
- IBuildServer
- IConfigurationGenerator
- InvokeBuildServerConfigurationGenerationAttribute
- NoConvertAttribute
- Partition
- Partition.TypeConverter
- PartitionAttribute
- ShutdownDotNetAfterServerBuildAttribute

### Nuke.Common

- Cleanup
- ControlFlow
- DefaultOutput
- DependencyBehavior
- DisableDefaultOutputAttribute
- ExecutableTargetExtensions
- Host
- INukeBuild
- ITargetDefinition
- Logger
- LogLevel
- NukeBuild
- OnDemandAttribute
- OnDemandValueInjectionAttribute
- OptionalAttribute
- ParameterAttribute
- ParameterPrefixAttribute
- RequiredAttribute
- RequiresAttribute
- RequiresAttribute<T>
- SecretAttribute
- Setup
- Target
- Verbosity

### Nuke.Common.Execution

- ArgumentsFromGitCommitMessageAttribute
- ArgumentsFromParametersFileAttribute
- BuildExtensionAttributeBase
- ExecutableTarget
- ExecutionStatus
- IBuildExtension
- IOnBuildCreated
- IOnBuildFinished
- IOnBuildInitialized
- IOnTargetFailed
- IOnTargetRunning
- IOnTargetSkipped
- IOnTargetSucceeded
- IOnTargetSummaryUpdated
- Logging
- Logging.InMemorySink
- Rider
- SchemaUtility
- Terminal
- UnsetVisualStudioEnvironmentVariablesAttribute
- VisualStudio
- VSCode

### Nuke.Common.Execution.Theming

- AnsiConsoleHostTheme
- IHostTheme
- SystemConsoleHostTheme

### Nuke.Common.Git

- GitProtocol
- GitRepository
- GitRepositoryExtensions

### Nuke.Common.Tooling

- ToolInjectionAttributeBase
- VerbosityMappingAttribute

### Nuke.Common.Utilities

- ConsoleUtility
- CredentialStore
- CustomFileWriter

### Nuke.Common.ValueInjection

- ValueInjectionAttributeBase

## Types & Methods

### Nuke.Common.CI.BuildServerConfigurationGeneration

- ConfigurationParameterName : string
- get_IsActive() : bool

### Nuke.Common.CI.BuildServerConfigurationGenerationAttributeBase

- .ctor()
- GetGenerators(INukeBuild build) : IEnumerable<IConfigurationGenerator>

### Nuke.Common.CI.ChainedConfigurationAttributeBase

- .ctor()
- get_ExcludedTargets() : string[]
- get_IrrelevantTargetNames() : IEnumerable<string>
- get_NonEntryTargets() : string[]
- set_ExcludedTargets(string[] value) : void
- set_NonEntryTargets(string[] value) : void
- GetInvokedTargets(ExecutableTarget executableTarget, IReadOnlyCollection<ExecutableTarget> relevantTargets) : IEnumerable<ExecutableTarget>
- GetTargetDependencies(ExecutableTarget executableTarget) : IEnumerable<ExecutableTarget>

### Nuke.Common.CI.CIAttribute

- .ctor()
- GetValue(MemberInfo member, object instance) : object

### Nuke.Common.CI.ConfigurationAttributeBase

- .ctor()
- get_AutoGenerate() : bool
- get_Build() : INukeBuild
- get_BuildCmdPath() : string
- get_ConfigurationFile() : AbsolutePath
- get_DisplayName() : string
- get_GeneratedFiles() : IEnumerable<AbsolutePath>
- get_HostName() : string
- get_HostType() : Type
- get_Id() : string
- get_IdPostfix() : string
- get_IrrelevantTargetNames() : IEnumerable<string>
- get_RelevantTargetNames() : IEnumerable<string>
- set_AutoGenerate(bool value) : void
- CreateStream() : StreamWriter
- CreateWriter(StreamWriter streamWriter) : CustomFileWriter
- Generate(IReadOnlyCollection<ExecutableTarget> executableTargets) : void
- GetConfiguration(IReadOnlyCollection<ExecutableTarget> relevantTargets) : ConfigurationEntity
- SerializeState() : void

### Nuke.Common.CI.ConfigurationEntity

- .ctor()
- Write(CustomFileWriter writer) : void

### Nuke.Common.CI.GenerateBuildServerConfigurationsAttribute

- .ctor()
- OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets) : void

### Nuke.Common.CI.IBuildServer

- get_Branch() : string
- get_Commit() : string

### Nuke.Common.CI.IConfigurationGenerator

- get_AutoGenerate() : bool
- get_DisplayName() : string
- get_GeneratedFiles() : IEnumerable<AbsolutePath>
- get_HostName() : string
- get_HostType() : Type
- get_Id() : string
- Generate(IReadOnlyCollection<ExecutableTarget> executableTargets) : void
- SerializeState() : void

### Nuke.Common.CI.InvokeBuildServerConfigurationGenerationAttribute

- .ctor()
- OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets) : void

### Nuke.Common.CI.NoConvertAttribute

- .ctor()

### Nuke.Common.CI.Partition

- .ctor()
- get_Part() : int
- get_Single() : Partition
- get_Total() : int
- set_Part(int value) : void
- set_Total(int value) : void
- GetCurrent(IEnumerable<T> enumerable) : IEnumerable<T>
- IsIn(int part) : bool
- ToString() : string

### Nuke.Common.CI.Partition.TypeConverter

- .ctor()
- CanConvertFrom(ITypeDescriptorContext context, Type sourceType) : bool
- ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) : object

### Nuke.Common.CI.PartitionAttribute

- .ctor(int total)
- get_List() : bool
- get_Total() : int
- GetValue(MemberInfo member, object instance) : object

### Nuke.Common.CI.ShutdownDotNetAfterServerBuildAttribute

- .ctor()
- get_EnableLogging() : bool
- get_Priority() : float
- set_EnableLogging(bool value) : void
- OnBuildFinished() : void

### Nuke.Common.Cleanup

- .ctor(object object, IntPtr method)
- BeginInvoke(ITargetDefinition definition, AsyncCallback callback, object object) : IAsyncResult
- EndInvoke(IAsyncResult result) : ITargetDefinition
- Invoke(ITargetDefinition definition) : ITargetDefinition

### Nuke.Common.ControlFlow

- Assert(bool condition, string text) : void
- ExecuteWithRetry(Action action, Action cleanup = null, int retryAttempts = 3, TimeSpan? delay = null, Action<string> logAction = null) : void
- Fail(string format, object[] args) : void
- Fail(object value, Exception exception = null) : void
- Fail(string text, Exception exception = null) : void
- NotEmpty(this IEnumerable<T> enumerable, string message = null) : IReadOnlyCollection<T>
- SuppressErrors(Action action, bool includeStackTrace = False, bool logWarning = True) : void
- SuppressErrors(Func<T> action, T defaultValue = null, bool includeStackTrace = False, bool logWarning = True) : T
- SuppressErrors(Func<IEnumerable<T>> action, bool includeStackTrace = False) : IEnumerable<T>

### Nuke.Common.DefaultOutput

- BuildOutcome : DefaultOutput
- ErrorsAndWarnings : DefaultOutput
- Logo : DefaultOutput
- TargetCollapse : DefaultOutput
- TargetHeader : DefaultOutput
- TargetOutcome : DefaultOutput
- Timestamps : DefaultOutput

### Nuke.Common.DependencyBehavior

- Execute : DependencyBehavior
- Skip : DependencyBehavior

### Nuke.Common.DisableDefaultOutputAttribute

- .ctor(DefaultOutput[] disabledOutputs)
- get_DisabledOutputs() : DefaultOutput[]
- IsApplicable(INukeBuild build) : bool

### Nuke.Common.ExecutableTargetExtensions

- Contains(this IEnumerable<ExecutableTarget> targets, Target target) : bool
- Contains(this IEnumerable<ExecutableTarget> targets, Setup target) : bool
- Contains(this IEnumerable<ExecutableTarget> targets, Cleanup target) : bool

### Nuke.Common.Execution.ArgumentsFromGitCommitMessageAttribute

- .ctor()
- get_Prefix() : string
- set_Prefix(string value) : void
- OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets) : void

### Nuke.Common.Execution.ArgumentsFromParametersFileAttribute

- .ctor()
- OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets) : void

### Nuke.Common.Execution.BuildExtensionAttributeBase

- .ctor()
- get_Build() : INukeBuild
- get_Priority() : float
- set_Priority(float value) : void

### Nuke.Common.Execution.ExecutableTarget

- .ctor()
- get_Actions() : List<Action>
- get_AllDependencies() : IReadOnlyCollection<ExecutableTarget>
- get_ArtifactDependencies() : LookupTable<ExecutableTarget, string>
- get_ArtifactProducts() : List<string>
- get_AssuredAfterFailure() : bool
- get_DelegateRequirements() : List<LambdaExpression>
- get_DependencyBehavior() : DependencyBehavior
- get_Description() : string
- get_Duration() : TimeSpan
- get_DynamicConditions() : List<(Text string, Delegate Func<bool>)>
- get_ExecutionDependencies() : List<ExecutableTarget>
- get_Factory() : Delegate
- get_Invoked() : bool
- get_IsDefault() : bool
- get_Listed() : bool
- get_Member() : MemberInfo
- get_Name() : string
- get_OnlyWhen() : string
- get_OrderDependencies() : List<ExecutableTarget>
- get_PartitionSize() : int?
- get_ProceedAfterFailure() : bool
- get_Skipped() : string
- get_StaticConditions() : List<(Text string, Delegate Func<bool>)>
- get_Status() : ExecutionStatus
- get_SummaryInformation() : Dictionary<string, string>
- get_ToolRequirements() : List<ToolRequirement>
- get_TriggerDependencies() : List<ExecutableTarget>
- get_Triggers() : List<ExecutableTarget>
- set_Description(string value) : void
- set_Factory(Delegate value) : void
- set_Invoked(bool value) : void
- set_IsDefault(bool value) : void
- set_Listed(bool value) : void
- set_Member(MemberInfo value) : void
- set_Name(string value) : void
- set_OnlyWhen(string value) : void
- set_PartitionSize(int? value) : void
- set_Skipped(string value) : void
- set_Status(ExecutionStatus value) : void

### Nuke.Common.Execution.ExecutionStatus

- Aborted : ExecutionStatus
- Collective : ExecutionStatus
- Failed : ExecutionStatus
- None : ExecutionStatus
- NotRun : ExecutionStatus
- Running : ExecutionStatus
- Scheduled : ExecutionStatus
- Skipped : ExecutionStatus
- Succeeded : ExecutionStatus

### Nuke.Common.Execution.IBuildExtension

- get_Priority() : float

### Nuke.Common.Execution.IOnBuildCreated

- OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets) : void

### Nuke.Common.Execution.IOnBuildFinished

- OnBuildFinished() : void

### Nuke.Common.Execution.IOnBuildInitialized

- OnBuildInitialized(IReadOnlyCollection<ExecutableTarget> executableTargets, IReadOnlyCollection<ExecutableTarget> executionPlan) : void

### Nuke.Common.Execution.IOnTargetFailed

- OnTargetFailed(ExecutableTarget target) : void

### Nuke.Common.Execution.IOnTargetRunning

- OnTargetRunning(ExecutableTarget target) : void

### Nuke.Common.Execution.IOnTargetSkipped

- OnTargetSkipped(ExecutableTarget target) : void

### Nuke.Common.Execution.IOnTargetSucceeded

- OnTargetSucceeded(ExecutableTarget target) : void

### Nuke.Common.Execution.IOnTargetSummaryUpdated

- OnTargetSummaryUpdated(INukeBuild build, ExecutableTarget target) : void

### Nuke.Common.Execution.Logging

- LevelSwitch : LoggingLevelSwitch
- get_Level() : LogLevel
- set_Level(LogLevel value) : void
- Configure(INukeBuild build = null) : void
- ConfigureConsole(this LoggerConfiguration configuration, INukeBuild build) : LoggerConfiguration
- ConfigureEnricher(this LoggerConfiguration configuration) : LoggerConfiguration
- ConfigureFiles(this LoggerConfiguration configuration, INukeBuild build) : LoggerConfiguration
- ConfigureFilter(this LoggerConfiguration configuration, INukeBuild build) : LoggerConfiguration
- ConfigureHost(this LoggerConfiguration configuration, INukeBuild build) : LoggerConfiguration
- ConfigureInMemory(this LoggerConfiguration configuration, INukeBuild build) : LoggerConfiguration
- ConfigureLevel(this LoggerConfiguration configuration) : LoggerConfiguration
- SetTarget(string name) : IDisposable

### Nuke.Common.Execution.Logging.InMemorySink

- get_Instance() : InMemorySink
- get_LogEvents() : IReadOnlyCollection<LogEvent>
- Dispose() : void
- Emit(LogEvent logEvent) : void

### Nuke.Common.Execution.Rider

- .ctor()

### Nuke.Common.Execution.SchemaUtility

- .ctor()
- GetJsonDocument(INukeBuild build) : JsonDocument
- GetJsonString(INukeBuild build) : string

### Nuke.Common.Execution.Terminal

- .ctor()
- get_IsRunningTerminal() : bool

### Nuke.Common.Execution.Theming.AnsiConsoleHostTheme

- .ctor(string successCode, IReadOnlyDictionary<ConsoleThemeStyle, string> styles)
- get_Default256AnsiColorTheme() : IHostTheme
- WriteDebug(string text) : void
- WriteError(string text) : void
- WriteInformation(string text) : void
- WriteSuccess(string text) : void
- WriteVerbose(string text = null) : void
- WriteWarning(string text) : void

### Nuke.Common.Execution.Theming.IHostTheme

- WriteDebug(string text = null) : void
- WriteError(string text = null) : void
- WriteInformation(string text = null) : void
- WriteSuccess(string text = null) : void
- WriteVerbose(string text = null) : void
- WriteWarning(string text = null) : void

### Nuke.Common.Execution.Theming.SystemConsoleHostTheme

- .ctor(SystemConsoleThemeStyle successStyle, IReadOnlyDictionary<ConsoleThemeStyle, SystemConsoleThemeStyle> styles)
- get_DefaultSystemColorTheme() : IHostTheme
- WriteDebug(string text) : void
- WriteError(string text) : void
- WriteInformation(string text) : void
- WriteSuccess(string text) : void
- WriteVerbose(string text = null) : void
- WriteWarning(string text) : void

### Nuke.Common.Execution.UnsetVisualStudioEnvironmentVariablesAttribute

- .ctor()
- OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets) : void

### Nuke.Common.Execution.VisualStudio

- .ctor()

### Nuke.Common.Execution.VSCode

- .ctor()

### Nuke.Common.Git.GitProtocol

- Https : GitProtocol
- Ssh : GitProtocol

### Nuke.Common.Git.GitRepository

- .ctor(GitProtocol? protocol, string endpoint, string identifier, string branch, AbsolutePath localDirectory, string head, string commit, IReadOnlyCollection<string> tags, string remoteName, string remoteBranch)
- get_Branch() : string
- get_Commit() : string
- get_Endpoint() : string
- get_Head() : string
- get_HttpsUrl() : string
- get_Identifier() : string
- get_LocalDirectory() : AbsolutePath
- get_Protocol() : GitProtocol?
- get_RemoteBranch() : string
- get_RemoteName() : string
- get_SshUrl() : string
- get_Tags() : IReadOnlyCollection<string>
- FromLocalDirectory(AbsolutePath directory) : GitRepository
- FromUrl(string url, string branch = null) : GitRepository
- SetBranch(string branch) : GitRepository
- ToString() : string

### Nuke.Common.Git.GitRepositoryExtensions

- IsOnDevelopBranch(this GitRepository repository) : bool
- IsOnFeatureBranch(this GitRepository repository) : bool
- IsOnHotfixBranch(this GitRepository repository) : bool
- IsOnMainBranch(this GitRepository repository) : bool
- IsOnMainOrMasterBranch(this GitRepository repository) : bool
- IsOnMasterBranch(this GitRepository repository) : bool
- IsOnReleaseBranch(this GitRepository repository) : bool

### Nuke.Common.Host

- .ctor()

### Nuke.Common.INukeBuild

- get_AbortedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_BuildAssemblyDirectory() : AbsolutePath
- get_BuildAssemblyFile() : AbsolutePath
- get_BuildProjectDirectory() : AbsolutePath
- get_BuildProjectFile() : AbsolutePath
- get_Continue() : bool
- get_ExecutionPlan() : IReadOnlyCollection<ExecutableTarget>
- get_ExitCode() : int?
- get_FailedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_FinishedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_Help() : bool
- get_Host() : Host
- get_InvokedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_IsFailing() : bool
- get_IsFinished() : bool
- get_IsLocalBuild() : bool
- get_IsServerBuild() : bool
- get_IsSucceeding() : bool
- get_NoLogo() : bool
- get_Partition() : Partition
- get_Plan() : bool
- get_RootDirectory() : AbsolutePath
- get_RunningTargets() : IReadOnlyCollection<ExecutableTarget>
- get_ScheduledTargets() : IReadOnlyCollection<ExecutableTarget>
- get_SkippedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_SucceededTargets() : IReadOnlyCollection<ExecutableTarget>
- get_TemporaryDirectory() : AbsolutePath
- get_Verbosity() : Verbosity
- set_ExitCode(int? value) : void
- ReportSummary(Configure<Dictionary<string, string>> configurator = null) : void
- TryGetValue(Expression<Func<T>> parameterExpression) : T
- TryGetValue(Expression<Func<object>> parameterExpression) : T

### Nuke.Common.ITargetDefinition

- After(Target[] targets) : ITargetDefinition
- After(Func<T, Target>[] targets) : ITargetDefinition
- AssuredAfterFailure() : ITargetDefinition
- Base() : ITargetDefinition
- Before(Target[] targets) : ITargetDefinition
- Before(Func<T, Target>[] targets) : ITargetDefinition
- Consumes(Target[] targets) : ITargetDefinition
- Consumes(Func<T, Target>[] targets) : ITargetDefinition
- Consumes(Target target, string[] artifacts) : ITargetDefinition
- Consumes(Func<T, Target> target, string[] artifacts) : ITargetDefinition
- Consumes(string[] artifacts) : ITargetDefinition
- DependentFor(Target[] targets) : ITargetDefinition
- DependentFor(Func<T, Target>[] targets) : ITargetDefinition
- DependsOn(Target[] targets) : ITargetDefinition
- DependsOn(Func<T, Target>[] targets) : ITargetDefinition
- DependsOnContext() : ITargetDefinition
- Description(string description) : ITargetDefinition
- Executes(Action[] actions) : ITargetDefinition
- Executes(Func<T> action) : ITargetDefinition
- Executes(Func<Task> action) : ITargetDefinition
- Inherit(Target[] targets) : ITargetDefinition
- Inherit(Expression<Func<T, Target>>[] targets) : ITargetDefinition
- OnlyWhenDynamic(Func<bool> condition, string conditionExpression = null) : ITargetDefinition
- OnlyWhenStatic(Func<bool> condition, string conditionExpression = null) : ITargetDefinition
- Partition(int size) : ITargetDefinition
- ProceedAfterFailure() : ITargetDefinition
- Produces(string[] artifacts) : ITargetDefinition
- Requires(Expression<Func<T>> parameterRequirement, Expression<Func<T>>[] parameterRequirements) : ITargetDefinition
- Requires(Expression<Func<T?>> parameterRequirement, Expression<Func<T?>>[] parameterRequirements) : ITargetDefinition
- Requires(Expression<Func<bool>> requirement, Expression<Func<bool>>[] requirements) : ITargetDefinition
- Requires() : ITargetDefinition
- Requires(string version) : ITargetDefinition
- Requires(Expression<Func<Tool>> tool, Expression<Func<Tool>>[] tools) : ITargetDefinition
- TriggeredBy(Target[] targets) : ITargetDefinition
- TriggeredBy(Func<T, Target>[] targets) : ITargetDefinition
- Triggers(Target[] targets) : ITargetDefinition
- Triggers(Func<T, Target>[] targets) : ITargetDefinition
- TryAfter(Func<T, Target>[] targets) : ITargetDefinition
- TryBefore(Func<T, Target>[] targets) : ITargetDefinition
- TryDependentFor(Func<T, Target>[] targets) : ITargetDefinition
- TryDependsOn(Func<T, Target>[] targets) : ITargetDefinition
- TryTriggeredBy(Func<T, Target>[] targets) : ITargetDefinition
- TryTriggers(Func<T, Target>[] targets) : ITargetDefinition
- Unlisted() : ITargetDefinition
- WhenSkipped(DependencyBehavior dependencyBehavior) : ITargetDefinition

### Nuke.Common.Logger

- Block(string text) : IDisposable
- Error(string format, object[] args) : void
- Error(object value) : void
- Error(string text = null) : void
- Error(Exception exception) : void
- Info(string format, object[] args) : void
- Info(object value) : void
- Info(string text = null) : void
- Log(LogLevel level, string text = null) : void
- Log(LogLevel level, string format, object[] args) : void
- Log(LogLevel level, object value) : void
- Normal(string format, object[] args) : void
- Normal(object value) : void
- Normal(string text = null) : void
- Success(string format, object[] args) : void
- Success(object value) : void
- Success(string text = null) : void
- Trace(string format, object[] args) : void
- Trace(object value) : void
- Trace(string text = null) : void
- Warn(string format, object[] args) : void
- Warn(object value) : void
- Warn(string text = null) : void
- Warn(Exception exception) : void

### Nuke.Common.LogLevel

- Error : LogLevel
- Normal : LogLevel
- Trace : LogLevel
- Warning : LogLevel

### Nuke.Common.NukeBuild

- .ctor()
- get_AbortedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_BuildAssemblyDirectory() : AbsolutePath
- get_BuildAssemblyFile() : AbsolutePath
- get_BuildProjectDirectory() : AbsolutePath
- get_BuildProjectFile() : AbsolutePath
- get_Continue() : bool
- get_ExecutionPlan() : IReadOnlyCollection<ExecutableTarget>
- get_ExitCode() : int?
- get_FailedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_FinishedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_Help() : bool
- get_Host() : Host
- get_InvokedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_IsFailing() : bool
- get_IsFinished() : bool
- get_IsLocalBuild() : bool
- get_IsServerBuild() : bool
- get_IsSucceeding() : bool
- get_LoadedLocalProfiles() : string[]
- get_NoLogo() : bool
- get_Partition() : Partition
- get_Plan() : bool
- get_RootDirectory() : AbsolutePath
- get_RunningTargets() : IReadOnlyCollection<ExecutableTarget>
- get_ScheduledTargets() : IReadOnlyCollection<ExecutableTarget>
- get_SkippedTargets() : IReadOnlyCollection<ExecutableTarget>
- get_SucceededTargets() : IReadOnlyCollection<ExecutableTarget>
- get_TemporaryDirectory() : AbsolutePath
- get_Verbosity() : Verbosity
- set_ExecutionPlan(IReadOnlyCollection<ExecutableTarget> value) : void
- set_ExitCode(int? value) : void
- set_Host(Host value) : void
- set_NoLogo(bool value) : void
- set_Verbosity(Verbosity value) : void
- Execute(Expression<Func<T, Target>>[] defaultTargetExpressions) : int
- ReportSummary(Configure<Dictionary<string, string>> configurator = null) : void

### Nuke.Common.OnDemandAttribute

- .ctor()

### Nuke.Common.OnDemandValueInjectionAttribute

- .ctor()

### Nuke.Common.OptionalAttribute

- .ctor()

### Nuke.Common.ParameterAttribute

- .ctor(string description = null)
- get_Description() : string
- get_List() : bool
- get_Name() : string
- get_Separator() : string
- get_ValueProviderMember() : string
- get_ValueProviderType() : Type
- set_List(bool value) : void
- set_Name(string value) : void
- set_Separator(string value) : void
- set_ValueProviderMember(string value) : void
- set_ValueProviderType(Type value) : void
- GetValue(MemberInfo member, object instance) : object
- GetValueSet(MemberInfo member, object instance) : IEnumerable<ValueTuple<string, object>>

### Nuke.Common.ParameterPrefixAttribute

- .ctor(string prefix)
- get_Prefix() : string

### Nuke.Common.RequiredAttribute

- .ctor()

### Nuke.Common.RequiresAttribute

- .ctor()
- GetRequirement() : ToolRequirement

### Nuke.Common.RequiresAttribute<T>

- .ctor()
- get_Version() : string
- set_Version(string value) : void
- GetRequirement() : ToolRequirement

### Nuke.Common.SecretAttribute

- .ctor()

### Nuke.Common.Setup

- .ctor(object object, IntPtr method)
- BeginInvoke(ITargetDefinition definition, AsyncCallback callback, object object) : IAsyncResult
- EndInvoke(IAsyncResult result) : ITargetDefinition
- Invoke(ITargetDefinition definition) : ITargetDefinition

### Nuke.Common.Target

- .ctor(object object, IntPtr method)
- BeginInvoke(ITargetDefinition definition, AsyncCallback callback, object object) : IAsyncResult
- EndInvoke(IAsyncResult result) : ITargetDefinition
- Invoke(ITargetDefinition definition) : ITargetDefinition

### Nuke.Common.Tooling.ToolInjectionAttributeBase

- .ctor()
- get_SuppressWarnings() : bool
- GetRequirement(MemberInfo member) : ToolRequirement

### Nuke.Common.Tooling.VerbosityMappingAttribute

- .ctor(Type targetType)
- get_Minimal() : string
- get_Normal() : string
- get_Quiet() : string
- get_Verbose() : string
- set_Minimal(string value) : void
- set_Normal(string value) : void
- set_Quiet(string value) : void
- set_Verbose(string value) : void
- OnBuildInitialized(IReadOnlyCollection<ExecutableTarget> executableTargets, IReadOnlyCollection<ExecutableTarget> executionPlan) : void

### Nuke.Common.Utilities.ConsoleUtility

- .ctor()
- PromptForChoice(string question, (Value T, Description string)[] options) : T
- PromptForInput(string question, string defaultValue) : string
- ReadSecret() : string

### Nuke.Common.Utilities.CredentialStore

- CreateNewPassword(out bool generated) : string
- DeletePassword(string name) : void
- GetPassword(string profile, string rootDirectory) : string
- SavePassword(string name, string password) : void
- TryGetPassword(string name) : string

### Nuke.Common.Utilities.CustomFileWriter

- .ctor(StreamWriter streamWriter, int indentationFactor, string commentPrefix)
- Indent() : IDisposable
- Write(Action<CustomFileWriter> writer) : void
- WriteComment(string text = null) : void
- WriteLine(string text = null) : void

### Nuke.Common.ValueInjection.ValueInjectionAttributeBase

- .ctor()
- get_Build() : INukeBuild
- get_Priority() : int
- get_SuppressWarnings() : bool
- GetMemberValue(string memberName, object instance) : T
- GetMemberValueOrNull(string memberName, object instance) : T
- GetValue(MemberInfo member, object instance) : object
- TryGetValue(MemberInfo member, object instance) : object

### Nuke.Common.Verbosity

- Minimal : Verbosity
- Normal : Verbosity
- Quiet : Verbosity
- Verbose : Verbosity
