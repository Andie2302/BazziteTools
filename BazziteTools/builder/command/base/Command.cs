using BazziteTools.builder.command.@base.interfaces;
namespace BazziteTools.builder.command.@base;
public class Command(string executableName)
{
    private readonly string _executable = executableName;
    private readonly List<ICommandParameter> _parameters = [];
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