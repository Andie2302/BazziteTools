using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.rpmostree;

public class RpmOstreeBuilder : LinuxCommandBuilder<RpmOstreeBuilder>
{
    public RpmOstreeBuilder() : base("rpm-ostree")
    {
    }

// In RpmOstreeBuilder.cs
    public RpmOstreeBuilder Install(params string[] packageNames)
    {
        AddArgument("install");
        foreach (var pkg in packageNames)
        {
            AddArgument(pkg);
        }

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

        if (Arguments.Count == 0)
        {
            report.AddError("Es wurde keine Aktion für rpm-ostree festgelegt.");
            return report;
        }

        // Warnung, wenn kein Reboot-Management geplant ist
        if (Arguments.Contains("install") && !Arguments.Contains("--apply-live"))
        {
            report.AddWarning(
                "Hinweis: Diese Installation wird erst nach einem Neustart aktiv, außer du nutzt .ApplyLive().");
        }

        return report;
    }
}