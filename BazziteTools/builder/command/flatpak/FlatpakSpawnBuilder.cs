namespace BazziteTools.builder.command.flatpak;

public class FlatpakSpawnBuilder : LinuxCommandBuilder
{
    public FlatpakSpawnBuilder() : base("flatpak-spawn")
    {
        // Standardmäßig wollen wir meistens auf den Host zugreifen
        AddLongOption("host");
    }

    public FlatpakSpawnBuilder Wrap(string command)
    {
        AddRawArgument(command);
        return this;
    }
}