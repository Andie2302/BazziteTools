namespace BazziteTools.builder.command.@base.interfaces;

public interface IKeyValueParameter<TKey, out TValue> : IKeyParameter<TKey>
{
    string Value { get; set; }
    string Separator { get; set; }
    public TValue WithValue(string value);
    public TValue WithSeparator(string separator);
}