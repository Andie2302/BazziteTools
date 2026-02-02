using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.distrobox;

namespace BazziteTools.builder.command.shell;

public class ShellPipelineBuilder : ICommandBuilder
{
    private readonly List<ICommandBuilder> _commands = [];

    public ShellPipelineBuilder Pipe(ICommandBuilder commandBuilder)
    {
        _commands.Add(commandBuilder);
        return this;
    }

    public string Build() => _commands.Count == 0 ? string.Empty : string.Join(" | ", _commands.Select(c => c.Build()));
    public CommandReport Validate()
    {
        var report = new CommandReport();
        foreach (var cmdErrors in _commands.Select(command => command.Validate()).Where(cmdErrors => !cmdErrors.IsSuccess))
        {
            report.AddErrors(cmdErrors.Errors);
        }
        return report;
    }
    
}