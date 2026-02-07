

using System.Diagnostics;
using BazziteTools.builder.command.@base;

public static class CommandExecutor
{
    public static async Task<CommandResult> ExecuteAsync(Command command)
    {
        string finalCommand = command.Build();
        
        var startInfo = new ProcessStartInfo
        {
            FileName = "bash",
            Arguments = $"-c \"{finalCommand.Replace("\"", "\\\"")}\"", 
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process();
        process.StartInfo = startInfo;

        try
        {
            process.Start();

            var outputTask = process.StandardOutput.ReadToEndAsync();
            var errorTask = process.StandardError.ReadToEndAsync();

            await Task.WhenAll(outputTask, errorTask);
            await process.WaitForExitAsync();

            return new CommandResult(
                process.ExitCode, 
                outputTask.Result.Trim(), 
                errorTask.Result.Trim(), 
                finalCommand);
        }
        catch (Exception ex)
        {
            return new CommandResult(-1, string.Empty, ex.Message, finalCommand);
        }
    }
}

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