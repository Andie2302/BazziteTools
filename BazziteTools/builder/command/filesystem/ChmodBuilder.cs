using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.filesystem;

public class ChmodBuilder : LinuxCommandBuilder<ChmodBuilder>
{
    public ChmodBuilder(string path) : base("chmod")
    {
        // Wir fügen den Pfad erst am Ende ein, daher merken wir ihn uns
        _path = path;
    }

    private readonly string _path;

    /// <summary>
    /// Macht die Datei ausführbar (+x).
    /// </summary>
    public ChmodBuilder MakeExecutable()
    {
        AddArgument("+x");
        return this;
    }

    /// <summary>
    /// Setzt die Berechtigungen im Oktalformat (z.B. 755).
    /// </summary>
    public ChmodBuilder SetMode(string mode)
    {
        AddArgument(mode);
        return this;
    }

    public override string Build()
    {
        return $"{base.Build()} {_path}";
    }

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (string.IsNullOrEmpty(_path)) report.AddError("Kein Zielpfad für chmod angegeben.");
        if (Arguments.Count == 0) report.AddError("Keine Berechtigungsänderung (z.B. MakeExecutable) angegeben.");
        return report;
    }
}