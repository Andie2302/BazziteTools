namespace BazziteTools.command.@base.builder.special;

public class LongFlagParameter : KeyParameter<LongFlagParameter>
{
    public LongFlagParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}