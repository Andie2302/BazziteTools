namespace BazziteTools;

public class CommandParameter:ICommandParameter
{
    public string Prefix { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Separator { get; set; } = string.Empty;
    public string Postfix { get; set; } = string.Empty;

    public override string ToString() => $"{Prefix}{Name}{Separator}{Value}{Postfix}";

    public CommandParameter WithPrefix(string prefix)
    {
        Prefix = prefix;
        return this;
    }

    public CommandParameter WithPostfix(string postfix)
    {
        Postfix = postfix;
        return this;
    }

    public CommandParameter WithSeparator(string separator)
    {
        Separator = separator;
        return this;
    }

    public CommandParameter WithValue(string value)
    {
        Value = value;
        return this;
    }

    public CommandParameter WithName(string name)
    {
        Name = name;
        return this;
    }
}