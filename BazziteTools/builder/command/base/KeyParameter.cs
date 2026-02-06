namespace BazziteTools.builder.command.@base;

public class KeyParameter : IKeyParameter<KeyParameter>
{
    public string Key { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    public string Suffix { get; set; } = string.Empty;

    public KeyParameter WithPrefix(string prefix)
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

    public virtual string Build() => $"{Prefix}{Key}{Suffix}";
}

// --- Spezialisierte Klassen ---

// Bei Optionen setzen wir das Leerzeichen als Standard-Trenner

// Für einfache Argumente (Pfade, Verben)

// --- Der Command Builder ---

// --- Die statische Hilfsklasse P ---