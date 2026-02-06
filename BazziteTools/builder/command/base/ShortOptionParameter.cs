namespace BazziteTools.builder.command.@base;

public class ShortOptionParameter : KeyValueParameter { public ShortOptionParameter() { Prefix = Prefixes.Dash.ToValue(); Separator = " "; } }