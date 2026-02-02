namespace BazziteTools.builder.command.@base;

public interface ICommand
{
    string Build();
    
    // Prüft, ob der Befehl ausgeführt werden kann
    bool IsValid(out List<string> errors);
}