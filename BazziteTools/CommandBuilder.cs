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

    public string Build()
    {
        return _commandBuilder.ToString();
    }

    public override string ToString()
    {
        return Build();
    }
}