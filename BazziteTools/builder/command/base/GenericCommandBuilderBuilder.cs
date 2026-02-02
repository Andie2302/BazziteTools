using System.ComponentModel.DataAnnotations;
using BazziteTools.builder.command.distrobox;

namespace BazziteTools.builder.command.@base;

public class GenericCommandBuilderBuilder(string binary) : LinuxCommandBuilderBuilder<GenericCommandBuilderBuilder>(binary)
{
    public override CommandReport Validate()
    {
        var commandReport = new CommandReport();
        return commandReport;
    }
}