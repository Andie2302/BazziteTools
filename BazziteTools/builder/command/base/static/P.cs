using BazziteTools.builder.command.@base.interfaces;
using BazziteTools.builder.command.@base.special;

namespace BazziteTools.builder.command.@base.@static;

public static class P
{
    public static LongFlagParameter LFlag(string key) => new() { Key = key };
    public static ShortFlagParameter Flag(string key) => new() { Key = key };
    
    public static LongOptionParameter LOpt(string key, string value) => new() { Key = key, Value = value };
    public static ShortOptionParameter Opt(string key, string value) => new() { Key = key, Value = value };

    public static KeyValueParameter Assign(string key, string value) => new() { Key = key, Value = value };
    
    public static KeyParameter Verb(string name) => new ArgumentParameter(name);
    public static ArgumentParameter Arg(string value) => new(value);
}