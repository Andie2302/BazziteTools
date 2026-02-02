namespace BazziteTools.builder.command.distrobox;

public class DistroboxAssembleBuilder : LinuxCommandBuilder
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