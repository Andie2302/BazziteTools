using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base;

public class KeyParameter : IKeyParameter<KeyParameter>
{
    public string Key { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    public string Suffix { get; set; } = string.Empty;

    private KeyParameter SetAndReturn(System.Action<string> assign, string value)
    {
        assign(value);
        return this;
    }

    public KeyParameter WithPrefix(string prefix) => SetAndReturn(v => Prefix = v, prefix);

    public KeyParameter WithSuffix(string suffix) => SetAndReturn(v => Suffix = v, suffix);

    public KeyParameter WithKey(string key) => SetAndReturn(v => Key = v, key);

    public virtual string Build() => $"{Prefix}{Key}{Suffix}";
}