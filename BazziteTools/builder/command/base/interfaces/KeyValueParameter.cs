namespace BazziteTools.builder.command.@base.interfaces;

public class KeyValueParameter : KeyParameter, IKeyValueParameter<KeyValueParameter, KeyValueParameter>
{
    public string Value { get; set; } = string.Empty;
    public string Separator { get; set; } = " ";

    public KeyValueParameter WithValue(string value)
    {
        Value = value;
        return this;
    }

    public KeyValueParameter WithSeparator(string separator)
    {
        Separator = separator;
        return this;
    }

    public new KeyValueParameter WithPrefix(string prefix)
    {
        base.WithPrefix(prefix);
        return this;
    }

    public new KeyValueParameter WithSuffix(string suffix)
    {
        base.WithSuffix(suffix);
        return this;
    }

    public new KeyValueParameter WithKey(string key)
    {
        base.WithKey(key);
        return this;
    }
    public override string Build() => $"{base.Build()}{Separator}{Value}";
}