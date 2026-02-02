namespace BazziteTools.builder.command.filesystem;

using @base;
using shell;

public static class FileSystemWorkflows
{
    /// <summary>
    /// Erstellt einen Ordner mit Root-Rechten und übergibt danach den Besitz an einen spezifischen Benutzer.
    /// </summary>
    /// <param name="path">Der Pfad, der erstellt werden soll.</param>
    /// <param name="username">Der Benutzer, der Besitzer des Ordners werden soll.</param>
    /// <returns>Ein kombinierter Befehl (Pipeline).</returns>
    public static ICommandBuilder PrepareAdminFolder(string path, string username)
    {
        return new ShellPipelineBuilder()
            .Pipe(FileSystem.CreateDirectory(path)
                .CreateParents()
                .AsRoot()) // sudo mkdir -p ...
            .Pipe(new ChownBuilder(path)
                .ToUser(username)
                .AsRoot()); // sudo chown ...
    }
}