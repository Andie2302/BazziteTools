namespace BazziteTools.interpreter;

using builder.command.distrobox;

public static class DistroboxListInterpreter
{
    public static IEnumerable<DistroboxContainer> Interpret(string rawOutput)
    {
        if (string.IsNullOrWhiteSpace(rawOutput))
            yield break;

        var lines = rawOutput.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            // Header oder Trenner überspringen
            if (line.Contains("ID") || line.Contains("---") || !line.Contains('|')) 
                continue;

            // Spalten trennen und säubern
            var parts = line.Split('|')
                .Select(p => p.Trim(' ', '|'))
                .ToArray();

            if (parts.Length >= 4)
            {
                yield return new DistroboxContainer
                {
                    Id = parts[0],
                    Name = parts[1],
                    Status = parts[2],
                    Image = parts[3]
                };
            }
        }
    }
}