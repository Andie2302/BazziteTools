using System.ComponentModel.DataAnnotations;
using BazziteTools.builder.command.distrobox;

namespace BazziteTools.builder.command.@base;

public class GenericCommandBuilder(string binary) : LinuxCommandBuilder<GenericCommandBuilder>(binary)
{
    public override CommandReport Validate()
    {
        var commandReport = new CommandReport();
        return commandReport;
    }
}