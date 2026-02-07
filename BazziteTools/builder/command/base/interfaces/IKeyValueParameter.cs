namespace BazziteTools.builder.command.@base.interfaces;

public interface IKeyValueParameter<out T, TValue> : IKeyParameter<T> where T : IKeyValueParameter<T, TValue>
{
    TValue Value { get; set; }
    string Separator { get; set; }
    T WithValue(TValue value);
    T WithSeparator(string separator);
}