namespace BazziteTools.builder.command.distrobox;

public static class DistroBox
{
    public static DistroboxCreateBuilder Create() => new();
    public static DistroboxEnterBuilder Enter(string name) => new(name);
    public static DistroboxRemoveBuilder Rm(string name) => new(name);

    public static DistroboxUpgradeBuilder Upgrade() => new();
    public static DistroboxAssembleBuilder Assemble() => new();
    public static DistroboxListBuilder List() => new DistroboxListBuilder();
}