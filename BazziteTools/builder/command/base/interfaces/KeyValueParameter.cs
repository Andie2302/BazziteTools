// KeyValueParameter.cs

using BazziteTools.builder.command.@base.enums;

namespace BazziteTools.builder.command.@base.interfaces;

public abstract class KeyValueParameter<T, TValue> : KeyParameter, IKeyValueParameter<T, TValue> 
    where T : KeyValueParameter<T, TValue>
{
    public TValue Value { get; set; } = default!;
    public string Separator { get; set; } = "=";

    public T WithValue(TValue value) { Value = value; return (T)this; }
    public T WithSeparator(string separator) { Separator = separator; return (T)this; }

    public override string Build() => $"{Prefix.ToValue()}{Key}{Separator}{Value}{Suffix}";
    public string Key { get; set; }
    public Prefixes Prefix { get; set; }
    public string Suffix { get; set; }
    public T WithPrefix(Prefixes prefix)
    {
        throw new NotImplementedException();
    }

    public T WithSuffix(string suffix)
    {
        throw new NotImplementedException();
    }

    public T WithKey(string key)
    {
        throw new NotImplementedException();
    }
}