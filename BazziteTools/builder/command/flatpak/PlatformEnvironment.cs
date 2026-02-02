namespace BazziteTools.builder.command.flatpak;


public static class PlatformEnvironment
{
    private const string FlatpakInfoPath = "/.flatpak-info";
    private const string NvidiaDriverPath = "/proc/driver/nvidia"; // Pfad zu den NVIDIA-Treiber-Infos

    public static bool IsFlatpak => File.Exists(FlatpakInfoPath);

    public static bool IsNvidiaDriverLoaded => Directory.Exists(NvidiaDriverPath);
}