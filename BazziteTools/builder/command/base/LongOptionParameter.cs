namespace BazziteTools.builder.command.@base;

public class LongOptionParameter : KeyValueParameter { public LongOptionParameter() { Prefix = Prefixes.DoubleDash.ToValue(); Separator = " "; } }