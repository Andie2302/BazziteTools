using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxCreateCommand
{
    private readonly Command _command;

    public DistroboxCreateCommand(string name)
    {
        _command = new Command("distrobox")
            .Add(P.Verb("create"), P.LOpt("name", name));
    }

    public DistroboxCreateCommand WithImage(string image)
    {
        _command.Add(P.LOpt("image", image));
        return this;
    }

    public DistroboxCreateCommand WithNvidia()
    {
        _command.Add(P.LFlag("nvidia"));
        return this;
    }

    public DistroboxCreateCommand WithPull()
    {
        _command.Add(P.LFlag("pull"));
        return this;
    }

    public string Build() => _command.Build();
    public override string ToString() => Build();
}