namespace BazziteTools;

public class CommandLongOption: CommandParameter
{
    public CommandLongOption(string name)
    {
        Prefix = "--";
        Name = name;
    }
}