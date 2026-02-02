namespace BazziteTools.builder.command.curl;

using BazziteTools.builder.command.@base;

/// <summary>
/// Ein spezialisierter Builder für curl-Befehle.
/// </summary>
public class CurlBuilder : LinuxCommandBuilder<CurlBuilder>
{
    /// <summary>
    /// Erstellt eine neue Instanz des CurlBuilders mit einer Ziel-URL.
    /// Da curl ohne Ziel nichts tut, wird die URL im Konstruktor erzwungen.
    /// </summary>
    /// <param name="url">Die Ziel-URL für den Datentransfer.</param>
    public CurlBuilder(string url) : base("curl")
    {
        AddArgument(url);
    }

    /// <summary>
    /// -f, --fail: Bricht bei Server-Fehlern (z.B. HTTP 404) sofort ab, ohne HTML-Fehlermeldungen auszugeben.
    /// </summary>
    public CurlBuilder Fail() => AddLongOption("fail");

    /// <summary>
    /// -s, --silent: Deaktiviert die Fortschrittsanzeige und Statusmeldungen.
    /// </summary>
    public CurlBuilder Silent() => AddLongOption("silent");

    /// <summary>
    /// -S, --show-error: Zeigt Fehlermeldungen an, auch wenn der Silent-Modus aktiv ist.
    /// </summary>
    public CurlBuilder ShowError() => AddLongOption("show-error");

    /// <summary>
    /// -L, --location: Folgt HTTP-Weiterleitungen (Redirects).
    /// </summary>
    public CurlBuilder FollowLocation() => AddLongOption("location");

    /// <summary>
    /// -o, --output: Speichert die heruntergeladenen Daten in der angegebenen Datei statt im Standard-Output.
    /// </summary>
    /// <param name="filePath">Der Zielpfad für die Datei.</param>
    public CurlBuilder Output(string filePath) => AddLongOption("output", filePath);

    /// <summary>
    /// -A, --user-agent: Setzt den User-Agent Header für die Anfrage.
    /// </summary>
    /// <param name="agent">Der Name des User-Agents.</param>
    public CurlBuilder UserAgent(string agent) => AddLongOption("user-agent", agent);

    /// <summary>
    /// Kombiniert die Standard-Flags für die Installation von Online-Skripten (-fsSL).
    /// </summary>
    public CurlBuilder ForInstallation() => Fail().Silent().ShowError().FollowLocation();
}