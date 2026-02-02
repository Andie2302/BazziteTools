using BazziteTools.builder.command.flatpak;
using CliWrap;
using CliWrap.EventStream;

public class LinuxCommandBuilder(string binary)
{
    private readonly List<string> _arguments = [];
    // Fügt ein einfaches Wort hinzu (Subcommand oder Positional)
    public LinuxCommandBuilder AddArgument(string arg)
    {
        return AddToken(arg);
    }
    // Fügt -f oder -rf hinzu
    public LinuxCommandBuilder AddShortOption(char option, string? value = null) 
    {
        AddToken($"-{option}");
        if (value != null) AddToken(value);
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
        var baseCommand = BuildBaseCommand();
        return PlatformEnvironment.IsFlatpak ? $"flatpak-spawn --host {baseCommand}" : baseCommand;
    }
    public LinuxCommandBuilder AddRawArgument(string arg)
    {
        return AddToken(arg);
    }
    public LinuxCommandBuilder AddCommandSeparator()
    {
        return AddToken("--");
    }
    public async Task ExecuteAsync()
    {
        var fullCommand = Build();
        var (cmdName, cmdArgs) = SplitCommand(fullCommand);
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

    private LinuxCommandBuilder AddToken(string token)
    {
        _arguments.Add(token);
        return this;
    }
    private string BuildBaseCommand() => $"{binary} {string.Join(" ", _arguments)}";
    private static (string Name, string Args) SplitCommand(string fullCommand)
    {
        var parts = fullCommand.Split(' ', 2);
        return (parts[0], parts.Length > 1 ? parts[1] : "");
    }
}