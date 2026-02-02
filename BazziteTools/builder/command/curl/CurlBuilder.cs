namespace BazziteTools.builder.command.curl;

using BazziteTools.builder.command.@base;

public class CurlBuilder : LinuxCommandBuilder<CurlBuilder>
{
    // Die URL ist fast immer Pflicht, also ab in den Konstruktor
    public CurlBuilder(string url) : base("curl")
    {
        AddArgument(url);
    }

    // -f, --fail: Bricht ab, wenn der Server einen Fehler (z.B. 404) meldet
    public CurlBuilder Fail() => AddLongOption("fail");

    // -s, --silent: Keine Fortschrittsanzeige (gut für Skripte)
    public CurlBuilder Silent() => AddLongOption("silent");

    // -S, --show-error: Zeigt Fehler trotzdem an, auch wenn silent aktiv ist
    public CurlBuilder ShowError() => AddLongOption("show-error");

    // -L, --location: Folgt Weiterleitungen (sehr wichtig für install.sh Downloads)
    public CurlBuilder FollowLocation() => AddLongOption("location");

    // -o, --output <file>: Speichert das Ergebnis in einer Datei
    public CurlBuilder Output(string filePath) => AddLongOption("output", filePath);

    // -A, --user-agent <name>: Gibt sich als ein bestimmter Browser aus
    public CurlBuilder UserAgent(string agent) => AddLongOption("user-agent", agent);
    
    public CurlBuilder ForInstallation() => Fail().Silent().ShowError().FollowLocation();
}