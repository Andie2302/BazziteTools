using BazziteTools.builder.command.shell;
using BazziteTools.builder.command.sudo;

namespace BazziteTools.builder.command.@base;

public static class CommandExtensions
{
    public static ShellPipelineBuilder PipeTo(this ICommandBuilder first, ICommandBuilder second)
    {
        return new ShellPipelineBuilder()
            .Pipe(first)
            .Pipe(second);
    }

    public static ShellPipelineBuilder PipeTo(this ShellPipelineBuilder pipeline, ICommandBuilder next)
    {
        return pipeline.Pipe(next);
    }

    public static ICommandBuilder WithSudo(this ICommandBuilder command) => new SudoBuilder(command);
}