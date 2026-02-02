using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;
public class DistroboxEnterBuilder : LinuxCommandBuilder<DistroboxEnterBuilder>
{
    public DistroboxEnterBuilder(string containerName) : base("distrobox")
    {
        AddArgument("enter");
        AddArgument(containerName);
    }

    public DistroboxEnterBuilder WithCommand(string command)
    {
        AddCommandSeparator();
        AddArgument(command);
        return this;
    }

    public DistroboxEnterBuilder Root()
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