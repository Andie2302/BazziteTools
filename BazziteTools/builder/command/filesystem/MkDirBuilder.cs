using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.filesystem;

public class MkDirBuilder : LinuxCommandBuilder<MkDirBuilder>
{
    public MkDirBuilder(string path) : base("mkdir")
    {
        AddArgument(path);
    }

    /// <summary>
    /// Erstellt auch alle übergeordneten Verzeichnisse, falls sie nicht existieren (-p).
    /// </summary>
    public MkDirBuilder CreateParents() => AddShortOption('p');

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (!Arguments.Any(a => !a.StartsWith("-")))
            report.AddError("Kein Pfad für das Verzeichnis angegeben.");
        return report;
    }
}