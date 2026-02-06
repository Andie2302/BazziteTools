namespace BazziteTools.builder.command.@base.interfaces;

public interface IKeyParameter<out TKey> : ICommandParameter
{
    string Key { get; set; }
    string Prefix { get; set; }
    string Suffix { get; set; }
    public TKey WithPrefix(string prefix);
    public TKey WithSuffix(string suffix);
    public TKey WithKey(string key);
}