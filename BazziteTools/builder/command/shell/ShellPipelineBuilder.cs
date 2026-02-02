namespace BazziteTools.builder.command.shell;

using BazziteTools.builder.command.@base;

public class ShellPipelineBuilder : ICommandBuilder
{
    private readonly List<ICommandBuilder> _commands = [];

    public ShellPipelineBuilder Pipe(ICommandBuilder command)
    {
        _commands.Add(command);
        return this;
    }

    public string Build() => string.Join(" | ", _commands.Select(c => c.Build()));

    public CommandReport Validate()
    {
        var globalReport = new CommandReport();
        foreach (var report in _commands.Select(command => command.Validate()))
        {
            foreach (var err in report.Errors) globalReport.AddError(err);
            foreach (var warn in report.Warnings) globalReport.AddWarning(warn);
        }
        return globalReport;
    }
}