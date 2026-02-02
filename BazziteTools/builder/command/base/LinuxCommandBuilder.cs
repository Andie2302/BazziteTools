using BazziteTools.builder.command.flatpak;
using CliWrap;
using CliWrap.EventStream;

namespace BazziteTools.builder.command.@base;

/// <summary>
/// Provides functionality for building Linux shell commands programmatically.
/// This class serves as a foundational component for constructing commands with
/// arguments, options, and other syntax required for executing shell operations.
/// </summary>
public abstract class LinuxCommandBuilder<T>(string binary) where T : LinuxCommandBuilder<T>
{
    private readonly List<string> _arguments = [];

    /// <summary>
    /// Adds a command argument token to the internal list of arguments for the Linux command being constructed.
    /// </summary>
    /// <param name="arg">The argument token to add to the command.</param>
    /// <returns>The <see cref="T"/> instance for method chaining.</returns>
    public T AddArgument(string arg)
    {
        return AddToken(arg);
    }

    /// <summary>
    /// Adds a short option token, prefixed with a single dash, to the internal list of arguments for the Linux command being constructed.
    /// Optionally, associates a value with the short option.
    /// </summary>
    /// <param name="option">The character representing the short option to add to the command.</param>
    /// <param name="value">The optional value to associate with the short option. If null, only the option will be added.</param>
    /// <returns>The <see cref="T"/> instance for method chaining.</returns>
    public T AddShortOption(char option, string? value = null) 
    {
        AddToken($"-{option}");
        if (value != null) AddToken(value);
        return (T) this;
    }

    /// <summary>
    /// Adds a long-form option to the internal list of arguments for the Linux command being constructed.
    /// </summary>
    /// <param name="option">The name of the long-form option (without the leading '--').</param>
    /// <param name="value">An optional value associated with the option. If null, the option will be added without a value.</param>
    /// <param name="separator">The character used to separate the option from its value if the value is provided.</param>
    /// <returns>The <see cref="T"/> instance for method chaining.</returns>
    public T AddLongOption(string option, string? value = null, char separator = ' ')
    {
        _arguments.Add(FormatLongOption(option, value, separator));
        return (T) this;
    }

    /// <summary>
    /// Formats a long option argument for a Linux command by combining the option name with its value,
    /// separated by a specified character, if provided.
    /// </summary>
    /// <param name="option">The name of the long option.</param>
    /// <param name="value">The value assigned to the option, or null if it does not accept a value.</param>
    /// <param name="separator">The character used to separate the option and its value. Defaults to a space (' ').</param>
    /// <returns>A formatted string representing the long option for the command.</returns>
    private static string FormatLongOption(string option, string? value, char separator) =>
        value is null
            ? $"--{option}"
            : $"--{option}{separator}{QuoteIfNeeded(value)}";

    /// <summary>
    /// Ensures that a given string is quoted if it contains spaces, making it suitable for inclusion in a Linux shell command.
    /// </summary>
    /// <param name="value">The string value to evaluate and quote if necessary.</param>
    /// <returns>The original string if it contains no spaces; otherwise, the string enclosed in double quotes.</returns>
    private static string QuoteIfNeeded(string value) => value.Contains(' ') ? $"\"{value}\"" : value;

    /// <summary>
    /// Constructs and returns the finalized shell command as a string. The command is tailored
    /// to the execution environment, adding additional syntax based on the platform's requirements.
    /// For example, on Flatpak environments, the resulting command includes a wrapper invocation.
    /// </summary>
    /// <returns>A string representation of the fully constructed shell command.</returns>
    public string Build()
    {
        var baseCommand = BuildBaseCommand();
        return PlatformEnvironment.IsFlatpak ? $"flatpak-spawn --host {baseCommand}" : baseCommand;
    }

    /// <summary>
    /// Adds a raw command argument token to the internal list of arguments for the Linux command being constructed.
    /// Unlike other methods that process options or flags, this method directly appends the raw argument as-is.
    /// </summary>
    /// <param name="arg">The raw argument token to add to the command.</param>
    /// <returns>The <see cref="T"/> instance for method chaining.</returns>
    public T AddRawArgument(string arg)
    {
        return AddToken(arg);
    }

    /// <summary>
    /// Adds a command separator token ("--") to the internal list of arguments.
    /// This is commonly used to indicate the end of command options and
    /// the beginning of positional arguments in Linux shell commands.
    /// </summary>
    /// <returns>The <see cref="T"/> instance for method chaining.</returns>
    public T AddCommandSeparator()
    {
        return AddToken("--");
    }

    /// <summary>
    /// Executes the constructed Linux command asynchronously and processes the output and error streams in real-time.
    /// </summary>
    /// <returns>A task that represents the asynchronous execution of the command.</returns>
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

    /// <summary>
    /// Adds a token to the internal list of arguments for the Linux command being constructed.
    /// </summary>
    /// <param name="token">The token to add to the command arguments.</param>
    /// <returns>The <see cref="T"/> instance for method chaining.</returns>
    private T AddToken(string token)
    {
        _arguments.Add(token);
        return (T) this;
    }

    /// <summary>
    /// Constructs the base command string by combining the binary name with its arguments.
    /// </summary>
    /// <returns>The fully constructed base command as a single string.</returns>
    private string BuildBaseCommand() => $"{binary} {string.Join(" ", _arguments)}";

    /// <summary>
    /// Splits a full command string into its binary name and arguments.
    /// </summary>
    /// <param name="fullCommand">The full command string to be split, consisting of the binary name and arguments.</param>
    /// <returns>A tuple containing the binary name as the first element and the arguments as the second element.</returns>
    private static (string Name, string Args) SplitCommand(string fullCommand)
    {
        var parts = fullCommand.Split(' ', 2);
        return (parts[0], parts.Length > 1 ? parts[1] : "");
    }
}