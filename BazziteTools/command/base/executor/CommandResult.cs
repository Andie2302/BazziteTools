namespace BazziteTools.command.@base.executor;

public record CommandResult(
    int ExitCode,
    string Output,
    string Error,
    string FullCommand)
{
    /// <summary>
    /// Gibt an, ob der Befehl erfolgreich (Exit Code 0) ausgeführt wurde.
    /// </summary>
    public bool Success => ExitCode == 0;

    public override string ToString() => Success
        ? $"Success: {Output}"
        : $"Failed (ExitCode: {ExitCode}): {Error}";
}