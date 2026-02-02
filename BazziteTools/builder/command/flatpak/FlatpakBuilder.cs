using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;

public class FlatpakBuilder : LinuxCommandBuilder
{
    public FlatpakBuilder() : base("flatpak") { }

    public FlatpakBuilder Run(string appId)
    {
        AddArgument("run");
        AddArgument(appId);
        return this;
    }

    public FlatpakBuilder Install(string source, string appId)
    {
        AddArgument("install");
        AddArgument(source);
        AddArgument(appId);
        return this;
    }

    public FlatpakBuilder User()
    {
        AddLongOption("user");
        return this;
    }

    public FlatpakBuilder AssumeYes()
    {
        AddShortOption('y');
        return this;
    }
}