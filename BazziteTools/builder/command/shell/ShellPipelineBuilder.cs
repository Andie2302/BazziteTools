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
    public bool IsValid(out ValidationResult validationResult)
    {
        validationResult = new ValidationResult();
        foreach (var command in _commands)
        {
            if (!command.IsValid(out var cmdErrors))
            {
                errors.AddRange(cmdErrors);
            }
        }
        return validationResult.IsSuccess;
    }
}