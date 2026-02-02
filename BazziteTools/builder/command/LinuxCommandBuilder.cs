namespace BazziteTools.builder.command;

public class LinuxCommandBuilder(string binary)
{
    private readonly List<string> _parts = [];

    // Fügt ein einfaches Wort hinzu (Subcommand oder Positional)
    public void AddArgument(string arg) => _parts.Add(arg);

    // Fügt -f oder -rf hinzu
    public void AddShortOption(char option, string? value = null) 
    {
        _parts.Add($"-{option}");
        if (value != null) _parts.Add(value);
    }

    // Fügt --long-option hinzu
    public void AddLongOption(string option, string? value = null, char separator = ' ')
    {
        if (value != null) _parts.Add($"--{option}{separator}{value}"); // Oder mit Leerzeichen
        else _parts.Add($"--{option}");
    }

    public string Build() => $"{binary} {string.Join(" ", _parts)}";
}