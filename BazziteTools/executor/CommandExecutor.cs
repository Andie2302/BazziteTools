using System.Diagnostics;
using BazziteTools.builder.command.@base;

namespace BazziteTools.executor;

public record ShellInfo(string ShellExecutable, string ShellArguments);


public class CommandExecutor
{
    public static ShellInfo ShellInfo { get; set; } = new("bash", "-c");

    public static async Task<string> ExecuteAsync(Command command)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = ShellInfo.ShellExecutable,
            Arguments = BuildShellArguments(command),
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

    private static string BuildShellArguments(Command command)
    {
        var escapedCommand = command.Build().Replace("\"", "\\\"");
        return $"{ShellInfo.ShellArguments} \"{escapedCommand}\"";
    }
}