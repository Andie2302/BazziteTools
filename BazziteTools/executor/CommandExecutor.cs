using System.Diagnostics;
using BazziteTools.builder.command.@base;

namespace BazziteTools.executor;

public class CommandExecutor
{
    private const string ShellExecutable = "bash";

    public async Task<string> ExecuteAsync(Command command)
    {
        // Wir nutzen bash -c, um sicherzustellen, dass Pipe-Operatoren 
        // und Linux-Pfad-Erweiterungen korrekt funktionieren.
        var startInfo = new ProcessStartInfo
        {
            FileName = ShellExecutable,
            Arguments = BuildBashArguments(command),
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = startInfo };

        try
        {
            process.Start();

            // Wir lesen Output und Error gleichzeitig aus
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                // Falls ein Fehler auftritt, geben wir die Fehlermeldung zurück
                return $"Error: {error}";
            }

            return output.Trim();
        }
        catch (Exception ex)
        {
            return $"Exception: {ex.Message}";
        }
    }

    private static string BuildBashArguments(Command command)
    {
        string escapedCommand = command.Build().Replace("\"", "\\\"");
        return $"-c \"{escapedCommand}\"";
    }
}
// ... existing code ...