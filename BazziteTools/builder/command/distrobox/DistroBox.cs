namespace BazziteTools.builder.command.distrobox;

public static class DistroBox
{
    public static DistroboxCreateBuilderBuilder Create() => new();
    public static DistroboxEnterBuilderBuilder Enter(string name) => new(name);
    public static DistroboxRemoveBuilderBuilder Rm(string name) => new(name);

    public static DistroboxUpgradeBuilderBuilder Upgrade() => new();
    public static DistroboxAssembleBuilderBuilder Assemble() => new();
}