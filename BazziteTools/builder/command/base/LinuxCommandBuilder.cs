using BazziteTools.builder.command.flatpak;

namespace BazziteTools.builder.command.@base;

public class LinuxCommandBuilder(string binary)
{
    private readonly List<string> _arguments = [];
    // Fügt ein einfaches Wort hinzu (Subcommand oder Positional)
    public LinuxCommandBuilder AddArgument(string arg)
    {
        _arguments.Add(arg);
        return this;
    }
    // Fügt -f oder -rf hinzu
    public LinuxCommandBuilder AddShortOption(char option, string? value = null) 
    {
        _arguments.Add($"-{option}");
        if (value != null) _arguments.Add(value);
        return this;
    }
    // Fügt --long-option hinzu
    // In LinuxCommandBuilder.cs
    public LinuxCommandBuilder AddLongOption(string option, string? value = null, char separator = ' ')
    {
        _arguments.Add(FormatLongOption(option, value, separator));
        return this;
    }

    private static string FormatLongOption(string option, string? value, char separator) =>
        value is null
            ? $"--{option}"
            : $"--{option}{separator}{QuoteIfNeeded(value)}";

    private static string QuoteIfNeeded(string value) => value.Contains(' ') ? $"\"{value}\"" : value;
    
    public string Build()
    {
        var baseCommand = $"{binary} {string.Join(" ", _arguments)}";

        // Wenn wir im Flatpak sind, müssen wir "rausspringen"
        return PlatformEnvironment.IsFlatpak ?
            // Wir nutzen hier direkt die Syntax für flatpak-spawn
            // Das QuoteIfNeeded sorgt dafür, dass der gesamte Befehl als ein Argument übergeben wird
            $"flatpak-spawn --host {baseCommand}" : baseCommand;
    }

    public LinuxCommandBuilder AddRawArgument(string arg)
    {
        _arguments.Add(arg);
        return this;
    }
    public LinuxCommandBuilder AddCommandSeparator()
    {
        _arguments.Add("--");
        return this;
    }

}