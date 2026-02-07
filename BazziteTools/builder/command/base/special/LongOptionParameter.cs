using BazziteTools.builder.command.@base.enums;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base.special;

public class LongOptionParameter : KeyValueParameter<LongOptionParameter, string>
{
    public LongOptionParameter()
    {
        Prefix = Prefixes.DoubleDash;
        Separator = " ";
    }
}