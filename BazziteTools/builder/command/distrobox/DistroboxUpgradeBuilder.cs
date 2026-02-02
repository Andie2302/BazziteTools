using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxUpgradeBuilder : LinuxCommandBuilder
{
    public DistroboxUpgradeBuilder() : base("distrobox") => AddArgument("upgrade");

    public DistroboxUpgradeBuilder All()
    {
        AddLongOption("all");
        return this;
    }

    public DistroboxUpgradeBuilder Name(string containerName)
    {
        AddArgument(containerName);
        return this;
    }
}