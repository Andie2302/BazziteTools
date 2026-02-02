using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;
public class DistroboxRemoveBuilder : LinuxCommandBuilder<DistroboxRemoveBuilder>
{
    public DistroboxRemoveBuilder(string containerName) : base("distrobox")
    {
        AddArgument("rm");
        AddArgument(containerName);
    }

    public DistroboxRemoveBuilder Force()
    {
        AddLongOption("force");
        return this;
    }

    public DistroboxRemoveBuilder Root()
    {
        AddLongOption("root");
        return this;
    }
}