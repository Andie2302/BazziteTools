using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.shell;

public class ShellPipelineBuilder : ICommand
{
    private readonly List<ICommand> _commands = [];

    public ShellPipelineBuilder Pipe(ICommand command)
    {
        _commands.Add(command);
        return this;
    }

    public string Build() => _commands.Count == 0 ? string.Empty : string.Join(" | ", _commands.Select(c => c.Build()));
}