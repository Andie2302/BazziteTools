namespace BazziteTools.builder.command.@base;

public static class P
{
    // Nutze den Konstruktor und setze den Key direkt
    public static LongFlagParameter LFlag(string key) => new LongFlagParameter { Key = key };
    public static ShortFlagParameter Flag(string key) => new ShortFlagParameter { Key = key };
    
    public static LongOptionParameter LOpt(string key, string value) => new LongOptionParameter { Key = key, Value = value };
    public static ShortOptionParameter Opt(string key, string value) => new ShortOptionParameter { Key = key, Value = value };

    public static KeyValueParameter Assign(string key, string value) => new KeyValueParameter { Key = key, Value = value };
    
    public static KeyParameter Verb(string name) => new ArgumentParameter(name);
    public static ArgumentParameter Arg(string value) => new(value);
}