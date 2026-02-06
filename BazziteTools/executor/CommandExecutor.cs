using System.Diagnostics;
using BazziteTools.builder.command.@base;

namespace BazziteTools.executor;

public class CommandExecutor
{
    private const string ShellExecutable = "bash";
    private const string ShellArguments = "-c";

    public static async Task<string> ExecuteAsync(Command command)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = ShellExecutable,
            Arguments = BuildBashArguments(command),
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

            var output = await process.StandardOutput.ReadToEndAsync();
            var error = await process.StandardError.ReadToEndAsync();

            await process.WaitForExitAsync();

            return process.ExitCode != 0 ? $"Error: {error}" : output.Trim();
        }
        catch (Exception ex)
        {
            return $"Exception: {ex.Message}";
        }
    }

    private static string BuildBashArguments(Command command)
    {
        var escapedCommand = command.Build().Replace("\"", "\\\"");
        return $"{ShellArguments} \"{escapedCommand}\"";
    }
}