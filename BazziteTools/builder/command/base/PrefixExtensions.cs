namespace BazziteTools.builder.command.@base;

public static class PrefixExtensions
{
    public static string ToValue(this Prefixes prefix) => prefix switch
    {
        Prefixes.Dash => "-",
        Prefixes.DoubleDash => "--",
        Prefixes.Slash => "/",
        _ => string.Empty
    };
}