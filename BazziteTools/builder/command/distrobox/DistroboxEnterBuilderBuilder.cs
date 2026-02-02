using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;
public class DistroboxEnterBuilderBuilder : LinuxCommandBuilderBuilder<DistroboxEnterBuilderBuilder>
{
    public DistroboxEnterBuilderBuilder(string containerName) : base("distrobox")
    {
        AddArgument("enter");
        AddArgument(containerName);
    }

    public DistroboxEnterBuilderBuilder WithCommand(string command)
    {
        AddCommandSeparator();
        AddArgument(command);
        return this;
    }

    public DistroboxEnterBuilderBuilder Root()
    {
        AddLongOption("root");
        return this;
    }
    
    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (Arguments.Count == 0) report.AddError("Kein Container-Name angegeben.");
        return report;
    }
}