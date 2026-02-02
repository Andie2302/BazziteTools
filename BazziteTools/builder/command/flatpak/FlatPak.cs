namespace BazziteTools.builder.command.flatpak;

public static class FlatPak
{
    public static FlatpakBuilderBuilder Command() => new();
    
    public static FlatpakSpawnBuilderBuilder Spawn() => new();

    public static FlatpakInstallBuilderBuilder Install(string? appId = null)
    {
        var builder = new FlatpakInstallBuilderBuilder();
        if (appId != null) 
        {
            builder.App(appId);
        }
        return builder;
    }
}