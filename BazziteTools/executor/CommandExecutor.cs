using System.Diagnostics;
using System.Text;
using BazziteTools.builder.command.@base;

namespace BazziteTools.executor;

public static class CommandExecutor
{
    public static async Task<CommandResult> ExecuteAsync(ICommandBuilder command)
    {
        // 1. Validierung prüfen
        var report = command.Validate();
        
        if (report.HasWarnings)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var warn in report.Warnings) Console.WriteLine($"[WARN] {warn}");
            Console.ResetColor();
        }

        if (!report.IsSuccess)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ausführung abgebrochen wegen Fehlern:");
            foreach (var err in report.Errors) Console.WriteLine($" - {err}");
            Console.ResetColor();
            return new CommandResult { ExitCode = -1, Error = "Validation failed" };
        }

        var outputBuilder = new StringBuilder();
        var errorBuilder = new StringBuilder();

        // 2. Befehl vorbereiten
        var commandText = command.Build();
        Console.WriteLine($"\n🚀 Führe aus: {commandText}");

        // 3. Prozess starten
        var psi = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"-c \"{commandText.Replace("\"", "\\\"")}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = new Process { StartInfo = psi };

        process.OutputDataReceived += (s, e) => 
        { 
            if (e.Data != null) 
            {
                Console.WriteLine(e.Data);
                outputBuilder.AppendLine(e.Data);
            }
        };
        process.ErrorDataReceived += (s, e) => 
        { 
            if (e.Data != null) 
            {
                errorBuilder.AppendLine(e.Data);
            }
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await process.WaitForExitAsync();
        
        return new CommandResult 
        { 
            ExitCode = process.ExitCode, 
            Output = outputBuilder.ToString().Trim(),
            Error = errorBuilder.ToString().Trim()
        };
    }
}