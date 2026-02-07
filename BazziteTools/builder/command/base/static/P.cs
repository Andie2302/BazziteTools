using BazziteTools.builder.command.@base.special;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base.@static;

public static class P
{
    public static LongOptionParameter LongOption(string key = "") 
        => new LongOptionParameter().WithKey(key);

    public static ShortFlagParameter ShortFlag(string key = "") 
        => new ShortFlagParameter().WithKey(key);
    
    public static LongFlagParameter LFlag(string key = "") 
        => new LongFlagParameter().WithKey(key);

    public static ShortFlagParameter Flag(string key = "") 
        => new ShortFlagParameter().WithKey(key);

    public static LongOptionParameter LOpt(string key = "", string value = "") 
        => new LongOptionParameter().WithKey(key).WithValue(value);

    public static ShortOptionParameter Opt(string key = "", string value = "") 
        => new ShortOptionParameter().WithKey(key).WithValue(value);

    public static KeyValueParameter<KeyValueParameter<dynamic, string>, string> Assign(string key = "", string value = "") 
        => new KeyValueParameter<KeyValueParameter<dynamic, string>, string>().WithKey(key).WithValue(value);

    public static KeyParameter Verb(string name = "") 
        => new KeyParameter().WithKey(name);

    public static ArgumentParameter Arg(string value) 
        => new ArgumentParameter(value);
}

   
