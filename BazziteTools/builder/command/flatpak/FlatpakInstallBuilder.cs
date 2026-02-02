using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;

public class FlatpakInstallBuilder : LinuxCommandBuilder
{
    public FlatpakInstallBuilder() : base("flatpak")
    {
        AddArgument("install");
    }

    // Ermöglicht die Auswahl der Quelle (standardmäßig flathub)
    public FlatpakInstallBuilder From(string remote = "flathub")
    {
        AddArgument(remote);
        return this;
    }

    // Die eigentliche App-ID (z.B. org.mozilla.firefox)
    public FlatpakInstallBuilder App(string appId)
    {
        AddArgument(appId);
        return this;
    }

    // Bestätigt alle Rückfragen automatisch (wichtig für Automatisierung)
    public FlatpakInstallBuilder AssumeYes()
    {
        AddShortOption('y');
        return this;
    }

    // Installiert die App nur für den aktuellen Nutzer (kein Sudo nötig)
    public FlatpakInstallBuilder User()
    {
        AddLongOption("user");
        return this;
    }
}