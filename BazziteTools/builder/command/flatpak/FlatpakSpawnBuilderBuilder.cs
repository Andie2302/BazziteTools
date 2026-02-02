using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;

public class FlatpakSpawnBuilderBuilder : LinuxCommandBuilderBuilder<FlatpakSpawnBuilderBuilder>
{
    public FlatpakSpawnBuilderBuilder() : base("flatpak-spawn")
    {
        AddLongOption("host");
    }

    public FlatpakSpawnBuilderBuilder Wrap(string command)
    {
        AddRawArgument(command);
        return this;
    }

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (Arguments.All(a => a.Contains("--host")))
            report.AddError("Kein Befehl zum Ausführen (Wrap) angegeben.");
        return report;
    }
}