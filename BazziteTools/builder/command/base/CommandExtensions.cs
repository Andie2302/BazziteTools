using BazziteTools.builder.command.shell;

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
}