using System.Text;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base;

public class Command(string executableName)
{
    private readonly List<ICommandParameter> _parameters = [];
    public bool UseSudo { get; set; }

    public Command Add(params ICommandParameter[] parameters)
    {
        _parameters.AddRange(parameters);
        return this;
    }

    public string Build()
    {
        var sb = new StringBuilder();

        if (UseSudo)
        {
            sb.Append("sudo ");
        }

        sb.Append(executableName);

        foreach (var parameter in _parameters)
        {
            sb.Append(' ');
            sb.Append(parameter.Build());
        }

        return sb.ToString();
    }

    public override string ToString() => Build();
}