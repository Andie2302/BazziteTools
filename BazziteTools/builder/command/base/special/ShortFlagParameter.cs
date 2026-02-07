using BazziteTools.builder.command.@base.enums;

namespace BazziteTools.builder.command.@base.special;

public class ShortFlagParameter : KeyParameter { public ShortFlagParameter() => Prefix = Prefixes.Dash; }