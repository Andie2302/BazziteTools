using BazziteTools.builder.command.@base.enums;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base.special;

// Hier geben wir 'LongOptionParameter' als T an die Basisklasse weiter
public class LongOptionParameter : KeyValueParameter<LongOptionParameter, string>
{
    public LongOptionParameter()
    {
        Prefix = Prefixes.DoubleDash;
        Separator = " "; // Standard für Long Options: --key value
    }
}