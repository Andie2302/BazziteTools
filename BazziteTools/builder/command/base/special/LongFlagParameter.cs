using BazziteTools.builder.command.@base.enums;

namespace BazziteTools.builder.command.@base.special;

public class LongFlagParameter : KeyParameter<LongFlagParameter>
{
    public LongFlagParameter()
    {
        Prefix = Prefixes.DoubleDash;
    }
}