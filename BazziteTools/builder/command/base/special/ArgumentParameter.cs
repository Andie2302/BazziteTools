using BazziteTools.builder.command.@base.enums;

namespace BazziteTools.builder.command.@base.special;

public class ArgumentParameter : KeyParameter<ArgumentParameter>
{
    public ArgumentParameter()
    {
        Prefix = Prefixes.None;
    }

    public ArgumentParameter WithValue(string value) => WithKey(value);

    // Wir überschreiben die Validierung der Basisklasse
    public override IEnumerable<string> Validate()
    {
        // Ein Argument darf keinen Prefix haben, muss aber einen Inhalt (Key) haben
        if (Prefix != Prefixes.None)
            yield return "ArgumentParameter darf kein Präfix haben.";
            
        if (string.IsNullOrWhiteSpace(Key))
            yield return "ArgumentParameter: Der Wert darf nicht leer sein.";
    }
}