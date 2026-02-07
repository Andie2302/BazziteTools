using BazziteTools.builder.command.@base.enums;

namespace BazziteTools.builder.command.@base.interfaces;

public interface IKeyParameter<out TKey> : ICommandParameter
{
    string Key { get; set; }
    Prefixes Prefix { get; set; }
    string Suffix { get; set; }
    public TKey WithPrefix(Prefixes prefix);
    public TKey WithSuffix(string suffix);
    public TKey WithKey(string key);
}

