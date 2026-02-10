using BazziteTools.command.@base.builder.special;

namespace BazziteTools.command.@base.builder.@static;

public static class P
{
    public static LongOptionParameter LongOption(string key = "") 
        => new LongOptionParameter().WithKey(key);

    public static ShortOptionParameter ShortOption(string key = "") 
        => new ShortOptionParameter().WithKey(key);

    public static LongFlagParameter LongFlag(string key = "") 
        => new LongFlagParameter().WithKey(key);

    public static ShortFlagParameter ShortFlag(string key = "") 
        => new ShortFlagParameter().WithKey(key);

    public static ArgumentParameter Argument(string value = "") 
        => new ArgumentParameter().WithValue(value);
}

