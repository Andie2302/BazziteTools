using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.shell;
using BazziteTools.builder.command.sudo;
using BazziteTools.executor;
using BazziteTools.interpreter;

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
    public static IEnumerable<DistroboxContainer> ToContainerList(this CommandResult result)
    {
        return DistroboxListInterpreter.Interpret(result.Output);
    }
}