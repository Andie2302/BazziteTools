using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.sudo;

public class SudoBuilder(ICommandBuilder command) : ICommandBuilder
{
    public string Build()
    {
        // Wir nehmen den Build-String des inneren Befehls und setzen sudo davor
        return $"sudo {command.Build()}";
    }

    public CommandReport Validate()
    {
        // Ein Sudo-Wrapper ist valide, wenn der innere Befehl valide ist
        var report = command.Validate();
        
        // Optionale Best-Practice Warnung für dich
        report.AddWarning("Dieser Befehl wird mit Root-Rechten ausgeführt. Sei vorsichtig!");
        
        return report;
    }
}