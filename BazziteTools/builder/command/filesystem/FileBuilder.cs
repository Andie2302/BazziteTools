using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.filesystem;

public class FileBuilder : LinuxCommandBuilder<FileBuilder>
{
    public FileBuilder(string filePath) : base("touch")
    {
        AddArgument(filePath);
    }

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (!Arguments.Any(a => !a.StartsWith("-")))
            report.AddError("Kein Dateipfad angegeben.");
        return report;
    }
}