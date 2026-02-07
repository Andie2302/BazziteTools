using BazziteTools.builder.command.@base.enums;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base.special;

// Hier geben wir 'LongOptionParameter' als T an die Basisklasse weiter
public class ShortOptionParameter : KeyValueParameter<ShortOptionParameter, string>
{
    public ShortOptionParameter()
    {
        Prefix = Prefixes.DoubleDash;
        Separator = " ";
    }
}