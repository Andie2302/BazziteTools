using System.Diagnostics;
using BazziteTools.command.@base.builder;

namespace BazziteTools.command.@base.executor;

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