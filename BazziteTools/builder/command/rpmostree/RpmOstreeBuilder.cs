using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.rpmostree;

public class RpmOstreeBuilder : LinuxCommandBuilder<RpmOstreeBuilder>
{
    public RpmOstreeBuilder() : base("rpm-ostree") { }

    public RpmOstreeBuilder Install(string packageName)
    {
        AddArgument("install");
        AddArgument(packageName);
        return this;
    }

    public RpmOstreeBuilder Upgrade()
    {
        AddArgument("upgrade");
        return this;
    }

    public RpmOstreeBuilder ApplyLive()
    {
        // Versucht Änderungen ohne Reboot anzuwenden (geht nicht immer)
        AddLongOption("apply-live");
        return this;
    }

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        
        if (!Arguments.Any())
        {
            report.AddError("Keine Aktion für rpm-ostree festgelegt (z.B. Install oder Upgrade).");
        }

        // Best Practice Hinweis für Bazzite-Nutzer
        if (Arguments.Contains("install") && !Arguments.Contains("--apply-live"))
        {
            report.AddWarning("Änderungen am System-Layer erfordern in der Regel einen Neustart, um aktiv zu werden.");
        }

        return report;
    }
}