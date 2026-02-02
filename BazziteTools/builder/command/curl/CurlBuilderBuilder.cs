namespace BazziteTools.builder.command.curl;

using BazziteTools.builder.command.@base;

/// <summary>
/// Ein spezialisierter Builder für curl-Befehle.
/// </summary>
public class CurlBuilderBuilder : LinuxCommandBuilderBuilder<CurlBuilderBuilder>
{
    /// <summary>
    /// Erstellt eine neue Instanz des CurlBuilders mit einer Ziel-URL.
    /// Da curl ohne Ziel nichts tut, wird die URL im Konstruktor erzwungen.
    /// </summary>
    /// <param name="url">Die Ziel-URL für den Datentransfer.</param>
    public CurlBuilderBuilder(string url) : base("curl")
    {
        AddArgument(url);
    }

    /// <summary>
    /// -f, --fail: Bricht bei Server-Fehlern (z.B. HTTP 404) sofort ab, ohne HTML-Fehlermeldungen auszugeben.
    /// </summary>
    public CurlBuilderBuilder Fail() => AddLongOption("fail");

    /// <summary>
    /// -s, --silent: Deaktiviert die Fortschrittsanzeige und Statusmeldungen.
    /// </summary>
    public CurlBuilderBuilder Silent() => AddLongOption("silent");

    /// <summary>
    /// -S, --show-error: Zeigt Fehlermeldungen an, auch wenn der Silent-Modus aktiv ist.
    /// </summary>
    public CurlBuilderBuilder ShowError() => AddLongOption("show-error");

    /// <summary>
    /// -L, --location: Folgt HTTP-Weiterleitungen (Redirects).
    /// </summary>
    public CurlBuilderBuilder FollowLocation() => AddLongOption("location");

    /// <summary>
    /// -o, --output: Speichert die heruntergeladenen Daten in der angegebenen Datei statt im Standard-Output.
    /// </summary>
    /// <param name="filePath">Der Zielpfad für die Datei.</param>
    public CurlBuilderBuilder Output(string filePath) => AddLongOption("output", filePath);

    /// <summary>
    /// -A, --user-agent: Setzt den User-Agent Header für die Anfrage.
    /// </summary>
    /// <param name="agent">Der Name des User-Agents.</param>
    public CurlBuilderBuilder UserAgent(string agent) => AddLongOption("user-agent", agent);

    /// <summary>
    /// Kombiniert die Standard-Flags für die Installation von Online-Skripten (-fsSL).
    /// </summary>
    public CurlBuilderBuilder ForInstallation() => Fail().Silent().ShowError().FollowLocation();
    
    public override CommandReport Validate()
    {
        var report = new CommandReport();
        var url = Arguments.FirstOrDefault();

        if (string.IsNullOrWhiteSpace(url))
        {
            report.AddError("Ziel-URL fehlt.");
            return report;
        }

        // Warnung bei unsicheren Protokollen
        if (url.StartsWith("http://") || url.StartsWith("ftp://") || url.StartsWith("ws://"))
        {
            report.AddWarning($"Sicherheits-Hinweis: Die URL nutzt ein unverschlüsseltes Protokoll ({url.Split(':')[0]}).");
        }

        return report;
    }

   
}