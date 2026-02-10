using BazziteTools.command.@base.builder.enums;

namespace BazziteTools.command.@base.builder.interfaces;

public abstract class KeyValueParameter<T, TValue> : KeyParameter<T>, IKeyValueParameter<T, TValue>
    where T : KeyValueParameter<T, TValue>
{
    public TValue Value { get; set; } = default!;
    public string Separator { get; set; } = "=";

    public T WithValue(TValue value)
    {
        Value = value;
        return (T)this;
    }

    public T WithSeparator(string separator)
    {
        Separator = separator;
        return (T)this;
    }

    public override string Build()
    {
        return $"{Prefix.ToValue()}{Key}{Separator}{Value}{Suffix}";
    }

    public override IEnumerable<string> Validate()
    {
        foreach (var error in base.Validate())
        {
            yield return error;
        }

        if (Value == null || string.IsNullOrWhiteSpace(Value.ToString()))
        {
            yield return $"{GetType().Name}: Der Wert (Value) darf nicht leer sein.";
        }
    }
}