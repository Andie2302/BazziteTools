namespace BazziteTools.command.@base.builder.special;

public class ShortFlagParameter : KeyParameter<ShortFlagParameter>
{
    public ShortFlagParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}