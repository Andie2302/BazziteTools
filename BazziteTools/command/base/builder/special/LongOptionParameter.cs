
namespace BazziteTools.command.@base.builder.special;

public class LongOptionParameter : KeyParameter<LongOptionParameter>
{
    public LongOptionParameter()
    {
        Prefix = enums.Prefixes.DoubleDash;
    }
}