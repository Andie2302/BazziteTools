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

    public string Build() => $"{binary} {string.Join(" ", _arguments)}";

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