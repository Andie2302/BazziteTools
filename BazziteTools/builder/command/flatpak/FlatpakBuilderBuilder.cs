using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;

public class FlatpakBuilderBuilder : LinuxCommandBuilderBuilder<FlatpakBuilderBuilder>
{
    public FlatpakBuilderBuilder() : base("flatpak")
    {
    }

    public FlatpakBuilderBuilder Run(string appId)
    {
        AddArgument("run");
        AddArgument(appId);
        return this;
    }

    public FlatpakBuilderBuilder Install(string source, string appId)
    {
        AddArgument("install");
        AddArgument(source);
        AddArgument(appId);
        return this;
    }

    public FlatpakBuilderBuilder User()
    {
        AddLongOption("user");
        return this;
    }

    public FlatpakBuilderBuilder AssumeYes()
    {
        AddShortOption('y');
        return this;
    }

    public override CommandReport Validate()
    {
        var commandReport = new CommandReport();
        return commandReport;
    }
}