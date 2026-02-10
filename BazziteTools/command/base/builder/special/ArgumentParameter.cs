using BazziteTools.command.@base.builder.enums;

namespace BazziteTools.command.@base.builder.special;

public class ArgumentParameter : KeyParameter<ArgumentParameter>
{
    public ArgumentParameter()
    {
        Prefix = Prefixes.None;
    }

    public ArgumentParameter WithValue(string value) => WithKey(value);

    public override IEnumerable<string> Validate()
    {
        if (Prefix != Prefixes.None)
            yield return "ArgumentParameter darf kein Präfix haben.";
            
        if (string.IsNullOrWhiteSpace(Key))
            yield return "ArgumentParameter: Der Wert darf nicht leer sein.";
    }
}