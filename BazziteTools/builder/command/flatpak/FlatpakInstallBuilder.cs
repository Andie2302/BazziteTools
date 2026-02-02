using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;
public class FlatpakInstallBuilder : LinuxCommandBuilder<FlatpakInstallBuilder>
{
    public FlatpakInstallBuilder() : base("flatpak")
    {
        AddArgument("install");
    }

    public FlatpakInstallBuilder From(string remote = "flathub")
    {
        AddArgument(remote);
        return this;
    }

    public FlatpakInstallBuilder App(string appId)
    {
        AddArgument(appId);
        return this;
    }

    public FlatpakInstallBuilder AssumeYes()
    {
        AddShortOption('y');
        return this;
    }

    public FlatpakInstallBuilder User()
    {
        AddLongOption("user");
        return this;
    }

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (Arguments.Count == 0) report.AddError("Keine Flatpak App-ID angegeben.");
        return report;
    }
}