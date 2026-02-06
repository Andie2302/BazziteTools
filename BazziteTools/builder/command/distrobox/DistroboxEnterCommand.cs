using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.@base.@static;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxEnterCommand(string name)
{
    private readonly Command _command = new Command("distrobox")
        .Add(P.Verb("enter"), P.Arg(name));

    public DistroboxEnterCommand Execute(string command)
    {
        _command.Add(P.LOpt("additional-flags", $"-c \"{command}\""));
        return this;
    }

    public string Build() => _command.Build();
    public override string ToString() => Build();
}