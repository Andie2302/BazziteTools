namespace BazziteTools.command.@base.builder.enums;

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