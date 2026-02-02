namespace BazziteTools.builder.command.@base;

public class GenericCommandBuilder(string binary) : LinuxCommandBuilder<GenericCommandBuilder>(binary)
{
    public override bool IsValid(out List<string> errors)
    {
        errors = [];
        return true;
    }
}