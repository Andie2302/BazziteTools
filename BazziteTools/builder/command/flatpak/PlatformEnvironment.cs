namespace BazziteTools.builder.command.flatpak;

public static class PlatformEnvironment
{
    private static readonly string FlatpakInfoPath = "/.flatpak-info";

    public static bool IsFlatpak => File.Exists(FlatpakInfoPath);
}