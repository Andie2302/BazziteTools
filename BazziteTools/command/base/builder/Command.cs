using System.Text;
using BazziteTools.command.@base.builder.interfaces;

namespace BazziteTools.command.@base.builder;

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
        var validationErrors = _parameters
            .SelectMany(p => p.Validate())
            .ToList();

        if (validationErrors.Count != 0)
        {
            throw new InvalidOperationException(
                "Kommando konnte nicht gebaut werden:\n" + 
                string.Join("\n", validationErrors));
        }

        var sb = new StringBuilder();
        if (UseSudo) sb.Append("sudo ");
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