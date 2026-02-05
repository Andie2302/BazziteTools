namespace BazziteTools;

public static class P // Kurz und knackig für die Benutzung
{
    // Das "Verb" ohne alles (distrobox ->create<-)
    public static CommandParameter Verb(string name) 
        => new CommandParameter().WithName(name);

    // Die klassische Option (--name ki-box)
    public static CommandParameter LongOption(string name, string value) 
        => new CommandParameter()
            .WithPrefix("--")
            .WithName(name)
            .WithSeparator(" ")
            .WithValue(value);

    // Die Kurz-Flag (-v)
    public static CommandParameter Flag(string name) 
        => new CommandParameter().WithPrefix("-").WithName(name);

    // Die Zuweisung (if=/dev/sda)
    public static CommandParameter Assign(string name, string value) 
        => new CommandParameter()
            .WithName(name)
            .WithSeparator("=")
            .WithValue(value);
}