using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;

public class FlatpakSpawnBuilder : LinuxCommandBuilder
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
}