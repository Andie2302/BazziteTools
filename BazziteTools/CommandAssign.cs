namespace BazziteTools;

public class CommandAssign : CommandParameter
{
    public CommandAssign(string name, string value)
    {
        Name = name;
        Separator = "=";
        Value = value;
    }
}