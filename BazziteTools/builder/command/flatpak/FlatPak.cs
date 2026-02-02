namespace BazziteTools.builder.command.flatpak;

public static class FlatPak
{
    public static FlatpakBuilder Command() => new();
    
    public static FlatpakSpawnBuilder Spawn() => new();

    // Diese Methode hat gefehlt oder hatte den falschen Parameter:
    public static FlatpakInstallBuilder Install(string? appId = null)
    {
        var builder = new FlatpakInstallBuilder();
        if (appId != null) 
        {
            builder.App(appId);
        }
        return builder;
    }
}