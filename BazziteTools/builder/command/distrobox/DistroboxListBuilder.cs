using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxListBuilder : LinuxCommandBuilder<DistroboxListBuilder>
{
    public DistroboxListBuilder() : base("distrobox")
    {
        AddArgument("list");
        // CSV-Format macht das Parsen für C# extrem einfach
    }

    public override CommandReport Validate()
    {
        // Dieser Befehl ist immer valide
        return new CommandReport();
    }
}