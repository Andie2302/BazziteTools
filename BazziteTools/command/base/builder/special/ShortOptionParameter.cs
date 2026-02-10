namespace BazziteTools.command.@base.builder.special;

public class ShortOptionParameter : KeyParameter<ShortOptionParameter>
{
    public ShortOptionParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}