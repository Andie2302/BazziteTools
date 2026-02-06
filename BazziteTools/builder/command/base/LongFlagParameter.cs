namespace BazziteTools.builder.command.@base;

public class LongFlagParameter : KeyParameter { public LongFlagParameter() => Prefix = Prefixes.DoubleDash.ToValue(); }