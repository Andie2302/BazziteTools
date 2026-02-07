using BazziteTools.builder.command.@base.enums;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base;

public class KeyParameter : IKeyParameter<KeyParameter>
{
    public string Key { get; set; } = string.Empty;
    public Prefixes Prefix { get; set; } = Prefixes.None;
    public string Suffix { get; set; } = string.Empty;
    public KeyParameter WithPrefix(Prefixes prefix)
    {
        Prefix = prefix;
        return this;
    }

    public KeyParameter WithSuffix(string suffix)
    {
        Suffix = suffix;
        return this;
    }

    public KeyParameter WithKey(string key)
    {
        Key = key;
        return this;
    }

    public virtual string Build() => $"{Prefix.ToValue()}{Key}{Suffix}";
}