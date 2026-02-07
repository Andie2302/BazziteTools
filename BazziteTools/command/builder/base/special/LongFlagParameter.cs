namespace BazziteTools.builder.command.@base.special;

public class LongFlagParameter : KeyParameter<LongFlagParameter>
{
    public LongFlagParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}