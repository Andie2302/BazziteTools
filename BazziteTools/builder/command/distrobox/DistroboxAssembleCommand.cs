using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxAssembleCommand
{
    private readonly Command _command;

    public DistroboxAssembleCommand()
    {
        _command = new Command("distrobox")
            .Add(P.Verb("assemble"));
    }

    public DistroboxAssembleCommand Create()
    {
        _command.Add(P.Verb("create"));
        return this;
    }

    public DistroboxAssembleCommand WithFile(string filePath)
    {
        _command.Add(P.LOpt("file", filePath));
        return this;
    }

    public DistroboxAssembleCommand Replace()
    {
        _command.Add(P.LFlag("replace"));
        return this;
    }

    public string Build() => _command.Build();
    public override string ToString() => Build();
}