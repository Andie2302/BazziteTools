namespace BazziteTools.builder.command.flatpak;

public static class FlatPak
{
    public static FlatpakBuilder Command() => new();
    public static FlatpakSpawnBuilder Spawn() => new();
}