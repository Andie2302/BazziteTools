using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxEnterBuilder : LinuxCommandBuilder
{
    public DistroboxEnterBuilder(string containerName) : base("distrobox")
    {
        AddArgument("enter");
        AddArgument(containerName);
    }

    public DistroboxEnterBuilder WithCommand(string command)
    {
        AddCommandSeparator();
        AddArgument(command);
        return this;
    }

    public DistroboxEnterBuilder Root()
    {
        AddLongOption("root");
        return this;
    }
}