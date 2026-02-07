namespace BazziteTools.builder.command.@base.special;

public class ShortOptionParameter : KeyParameter<ShortOptionParameter>
{
    public ShortOptionParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}