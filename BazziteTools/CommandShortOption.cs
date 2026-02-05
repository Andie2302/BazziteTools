namespace BazziteTools;

public class CommandShortOption: CommandParameter
{
    public CommandShortOption(string name)
    {
        Prefix = "-";
        Name = name;
    }
}