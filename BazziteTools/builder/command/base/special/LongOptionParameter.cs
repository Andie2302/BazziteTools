
namespace BazziteTools.builder.command.@base.special;

public class LongOptionParameter : KeyParameter<LongOptionParameter>
{
    public LongOptionParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}