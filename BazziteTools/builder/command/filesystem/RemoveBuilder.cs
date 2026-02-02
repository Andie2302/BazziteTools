using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.filesystem;

public class RemoveBuilder : LinuxCommandBuilder<RemoveBuilder>
{
    public RemoveBuilder(string path) : base("rm")
    {
        AddArgument(path);
    }

    /// <summary>
    /// Löscht Verzeichnisse und deren Inhalte rekursiv (-r).
    /// </summary>
    public RemoveBuilder Recursive() => AddShortOption('r');

    /// <summary>
    /// Erzwingt das Löschen ohne Nachfrage (-f).
    /// </summary>
    public RemoveBuilder Force() => AddShortOption('f');

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        var path = Arguments.FirstOrDefault(a => !a.StartsWith("-"));

        if (string.IsNullOrEmpty(path))
            report.AddError("Kein Pfad zum Löschen angegeben.");
        
        // Sicherheits-Check für Andreas
        if (path == "/" || path == "/home" || path == "/usr")
            report.AddError($"Gefährlicher Löschbefehl erkannt: {path}. Das Löschen von Systempfaden ist blockiert.");

        return report;
    }
}