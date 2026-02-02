using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxRemoveBuilderBuilder : LinuxCommandBuilderBuilder<DistroboxRemoveBuilderBuilder>
{
    public DistroboxRemoveBuilderBuilder(string containerName) : base("distrobox")
    {
        AddArgument("rm");
        AddArgument(containerName);
    }

    public DistroboxRemoveBuilderBuilder Force()
    {
        AddLongOption("force");
        return this;
    }

    public DistroboxRemoveBuilderBuilder Root()
    {
        AddLongOption("root");
        return this;
    }

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (Arguments.Count == 0) 
            report.AddError("Kein Container-Name angegeben.");
        return report;
    }
}