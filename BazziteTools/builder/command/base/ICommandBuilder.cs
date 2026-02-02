using BazziteTools.builder.command.distrobox;

namespace BazziteTools.builder.command.@base;

public interface ICommandBuilder
{
    string Build();
    CommandReport Validate();
}