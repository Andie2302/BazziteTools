namespace BazziteTools.builder.command.@base;

public class Command
{
    private readonly string _executable;
    private readonly List<ICommandParameter> _parameters = new();

    public Command(string executable) => _executable = executable;

    // Jetzt mit 'params' für mehrere Parameter gleichzeitig
    public Command Add(params ICommandParameter[] parameters)
    {
        _parameters.AddRange(parameters);
        return this;
    }

    public string Build()
    {
        var rendered = _parameters.Select(p => p.Build());
        return $"{_executable} {string.Join(" ", rendered)}".Trim();
    }

    public override string ToString() => Build();
}