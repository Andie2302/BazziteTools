using BazziteTools.builder.command.flatpak;
using CliWrap;
using CliWrap.EventStream;

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

        return PlatformEnvironment.IsFlatpak ? $"flatpak-spawn --host {baseCommand}" : baseCommand;
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
    public async Task ExecuteAsync()
    {
        var fullCommand = Build();
        // CliWrap braucht den ersten Teil als Binary und den Rest als Argumente
        // Da unser Build() aber ggf. flatpak-spawn vorn dran hat, splitten wir vorsichtig
        var parts = fullCommand.Split(' ', 2);
        var cmdName = parts[0];
        var cmdArgs = parts.Length > 1 ? parts[1] : "";

        await foreach (var cmdEvent in Cli.Wrap(cmdName).WithArguments(cmdArgs).ListenAsync())
        {
            switch (cmdEvent)
            {
                case StandardOutputCommandEvent stdOut:
                    Console.WriteLine($"[OUT] {stdOut.Text}");
                    break;
                case StandardErrorCommandEvent stdErr:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERR] {stdErr.Text}");
                    Console.ResetColor();
                    break;
                case ExitedCommandEvent exited:
                    Console.WriteLine($"Prozess beendet mit Code: {exited.ExitCode}");
                    break;
            }
        }
    }
}