namespace BazziteTools.builder.command.distrobox;

public static class DistroboxParser
{
    public static List<DistroboxContainer> ParseList(string output)
    {
        var lines = output.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        return (from line in lines.Skip(1) select line.Split('|').Select(p => p.Trim()).ToArray() into parts where parts.Length >= 4 select new DistroboxContainer(Id: parts[0], Name: parts[1], Status: parts[2], Image: parts[3])).ToList();
    }
}