using System.Diagnostics;
using BazziteTools.builder.command.@base;

namespace BazziteTools.executor;

public static class CommandExecutor
{
    public static async Task ExecuteAsync(ICommandBuilder command)
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
            return;
        }

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

        process.OutputDataReceived += (s, e) => { if (e.Data != null) Console.WriteLine(e.Data); };
        process.ErrorDataReceived += (s, e) => { if (e.Data != null) Console.Error.WriteLine($"[ERROR] {e.Data}"); };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await process.WaitForExitAsync();
        
        if (process.ExitCode == 0)
            Console.WriteLine("✅ Befehl erfolgreich beendet.");
        else
            Console.WriteLine($"❌ Befehl beendet mit Code: {process.ExitCode}");
    }
}