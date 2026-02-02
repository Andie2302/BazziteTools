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

    public override bool IsValid(out List<string> errors)
    {
        errors = [];
        if (!_arguments.Any(a => !a.Contains("--host")))
            errors.Add("Kein Befehl zum Ausführen (Wrap) angegeben.");
        return errors.Count == 0;
    }
}