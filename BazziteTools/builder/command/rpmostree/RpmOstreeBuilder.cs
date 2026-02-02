using BazziteTools.builder.command.@base;
namespace BazziteTools.builder.command.rpmostree;
public class RpmOstreeBuilder : LinuxCommandBuilder<RpmOstreeBuilder>
{
    private const string InstallCommand = "install";
    private const string UpgradeCommand = "upgrade";
    private const string ApplyLiveOption = "apply-live";
    private const string ApplyLiveArgument = "--apply-live";

    private const string NoActionError = "Es wurde keine Aktion für rpm-ostree festgelegt.";
    private const string InstallRebootWarning =
        "Hinweis: Diese Installation wird erst nach einem Neustart aktiv, außer du nutzt .ApplyLive().";

    public RpmOstreeBuilder() : base("rpm-ostree")
    {
    }
    // In RpmOstreeBuilder.cs
    public RpmOstreeBuilder Install(params string[] packageNames)
    {
        AddArgument(InstallCommand);
        AddArguments(packageNames);
        return this;
    }
    public RpmOstreeBuilder Upgrade()
    {
        AddArgument(UpgradeCommand);
        return this;
    }
    public RpmOstreeBuilder ApplyLive()
    {
        // Versucht Änderungen ohne Reboot anzuwenden (geht nicht immer)
        AddLongOption(ApplyLiveOption);
        return this;
    }
    public override CommandReport Validate()
    {
        var validation = new CommandReport();
        if (Arguments.Count == 0)
        {
            validation.AddError(NoActionError);
            return validation;
        }
        // Warnung, wenn kein Reboot-Management geplant ist
        if (Arguments.Contains(InstallCommand) && !Arguments.Contains(ApplyLiveArgument))
        {
            validation.AddWarning(InstallRebootWarning);
        }
        return validation;
    }

    private void AddArguments(IEnumerable<string> args)
    {
        foreach (var arg in args)
        {
            AddArgument(arg);
        }
    }
}