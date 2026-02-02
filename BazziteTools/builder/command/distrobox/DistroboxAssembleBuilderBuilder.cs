using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxAssembleBuilderBuilder : LinuxCommandBuilderBuilder<DistroboxAssembleBuilderBuilder>
{
    public DistroboxAssembleBuilderBuilder() : base("distrobox") => AddArgument("assemble");

    public DistroboxAssembleBuilderBuilder Create()
    {
        AddArgument("create");
        return this;
    }

    public DistroboxAssembleBuilderBuilder File(string path)
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