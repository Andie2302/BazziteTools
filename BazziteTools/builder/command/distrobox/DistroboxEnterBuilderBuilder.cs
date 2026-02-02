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
    
    public override bool IsValid(out List<string> errors)
    {
        errors = [];
        // Wir prüfen, ob ein Argument vorhanden ist, das nicht mit "-" startet (der Container-Name)
        // oder ob ein Name-Flag gesetzt wurde.
        if (!_arguments.Any()) errors.Add("Kein Container-Name angegeben.");
        return errors.Count == 0;
    }
}