using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxAssembleBuilder : LinuxCommandBuilder<DistroboxAssembleBuilder>
{
    public DistroboxAssembleBuilder() : base("distrobox") => AddArgument("assemble");

    public DistroboxAssembleBuilder Create()
    {
        AddArgument("create");
        return this;
    }

    public DistroboxAssembleBuilder File(string path)
    {
        AddLongOption("file", path);
        return this;
    }

    public override bool IsValid(out ValidationResult errors)
    {
        errors = new ValidationResult();
        if (!_arguments.Any(a => a.Contains("--file")))
        {
            errors.AddWarning("Keine Datei angegeben. Verwende 'distrobox.ini' als Standard.");
        }
        return true; 
    }
    
}