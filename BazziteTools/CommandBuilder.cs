using System.Text;

namespace BazziteTools;

public class CommandBuilder
{
    private readonly StringBuilder _commandBuilder = new();

    public CommandBuilder(string executable, params CommandParameter[] parameters)
    {
        _commandBuilder.Append(executable);
        AddRange(parameters);
    }

    public CommandBuilder Add(CommandParameter parameter)
    {
        _commandBuilder.Append(' ');
        _commandBuilder.Append(parameter);
        return this;
    }
    public CommandBuilder AddRange(params CommandParameter[] parameter)
    {
        foreach (var commandParameter in parameter)
            Add(commandParameter);
        return this;
    }

    public string Build() => _commandBuilder.ToString();
    public override string ToString() => Build();
}

public class CommandParameter
{
    public string Prefix { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Separator { get; set; } = string.Empty;
    public string Postfix { get; set; } = string.Empty; 
    public override string ToString() => $"{Prefix}{Name}{Separator}{Value}{Postfix}";
}