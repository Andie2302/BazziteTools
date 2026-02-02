namespace BazziteTools.builder.command.filesystem;

public static class FileSystem
{
    public static MkDirBuilder CreateDirectory(string path) => new MkDirBuilder(path);
    public static FileBuilder CreateFile(string path) => new FileBuilder(path);
    public static RemoveBuilder Remove(string path) => new RemoveBuilder(path);
    public static ChmodBuilder ChangePermissions(string path) => new ChmodBuilder(path);
}