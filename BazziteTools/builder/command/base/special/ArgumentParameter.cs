using BazziteTools.builder.command.@base.enums;

namespace BazziteTools.builder.command.@base.special;

public class ArgumentParameter : KeyParameter<ArgumentParameter>
{
    public ArgumentParameter() => Prefix = Prefixes.None;

    public ArgumentParameter WithValue(string value) => WithKey(value);
}