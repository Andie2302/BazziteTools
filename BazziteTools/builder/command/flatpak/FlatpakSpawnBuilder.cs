using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;

public class FlatpakSpawnBuilder : LinuxCommandBuilder<FlatpakSpawnBuilder>
{
    public FlatpakSpawnBuilder() : base("flatpak-spawn")
    {
        AddLongOption("host");
    }

    public FlatpakSpawnBuilder Wrap(string command)
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