using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;
public class DistroboxUpgradeBuilderBuilder : LinuxCommandBuilderBuilder<DistroboxUpgradeBuilderBuilder>
{
    public DistroboxUpgradeBuilderBuilder() : base("distrobox") => AddArgument("upgrade");

    public DistroboxUpgradeBuilderBuilder All()
    {
        AddLongOption("all");
        return this;
    }

    public DistroboxUpgradeBuilderBuilder Name(string containerName)
    {
        AddArgument(containerName);
        return this;
    }
}