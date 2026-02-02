using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxAssembleBuilder : LinuxCommandBuilder<DistroboxAssembleBuilder>
{
    public DistroboxAssembleBuilder() : base("distrobox") => AddArgument("assemble");

    public DistroboxAssembleBuilder Create()
    {
        AddArgument("create");
        return this;
    }

    public DistroboxAssembleBuilder File(string path)
    {
        AddLongOption("file", path);
        return this;
    }

    
}