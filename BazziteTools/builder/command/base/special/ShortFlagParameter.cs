namespace BazziteTools.builder.command.@base.special;

public class ShortFlagParameter : KeyParameter<ShortFlagParameter>
{
    public ShortFlagParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}