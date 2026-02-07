using BazziteTools.builder.command.@base.enums;
using BazziteTools.builder.command.@base.interfaces;

namespace BazziteTools.builder.command.@base.special;

public class ShortOptionParameter : KeyValueParameter { public ShortOptionParameter() { Prefix = Prefixes.Dash; Separator = " "; } }