using BazziteTools.builder.command.@base.enums;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base;

public abstract class KeyParameter<T> : IKeyParameter<T> where T : KeyParameter<T>
{
    public string Key { get; set; } = string.Empty;
    public Prefixes Prefix { get; set; } = Prefixes.None;
    public string Suffix { get; set; } = string.Empty;

    public T WithPrefix(Prefixes prefix)
    {
        Prefix = prefix;
        return (T)this;
    }

    public T WithSuffix(string suffix)
    {
        Suffix = suffix;
        return (T)this;
    }

    public T WithKey(string key)
    {
        Key = key;
        return (T)this;
    }

    public virtual string Build()
    {
        return $"{Prefix.ToValue()}{Key}{Suffix}";
    }
}