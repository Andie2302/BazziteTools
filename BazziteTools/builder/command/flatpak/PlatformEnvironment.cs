namespace BazziteTools.builder.command.flatpak;

public static class PlatformEnvironment
{
    // Auf Linux-Systemen signalisiert die Existenz dieser Datei die Flatpak-Sandbox
    private static readonly string FlatpakInfoPath = "/.flatpak-info";

    public static bool IsFlatpak => File.Exists(FlatpakInfoPath);
}