namespace BazziteTools.command.@base.builder.interfaces;

public interface ICommandParameter 
{
    string Build(); 
    IEnumerable<string> Validate();
}