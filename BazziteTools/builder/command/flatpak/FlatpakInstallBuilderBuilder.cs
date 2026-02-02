using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.flatpak;
public class FlatpakInstallBuilderBuilder : LinuxCommandBuilderBuilder<FlatpakInstallBuilderBuilder>
{
    public FlatpakInstallBuilderBuilder() : base("flatpak")
    {
        AddArgument("install");
    }

    public FlatpakInstallBuilderBuilder From(string remote = "flathub")
    {
        AddArgument(remote);
        return this;
    }

    public FlatpakInstallBuilderBuilder App(string appId)
    {
        AddArgument(appId);
        return this;
    }

    public FlatpakInstallBuilderBuilder AssumeYes()
    {
        AddShortOption('y');
        return this;
    }

    public FlatpakInstallBuilderBuilder User()
    {
        AddLongOption("user");
        return this;
    }public override bool IsValid(out List<string> errors)
    {
        errors = [];
        // Die App-ID ist bei dir das erste oder zweite Argument
        if (!_arguments.Any()) errors.Add("Keine Flatpak App-ID angegeben.");
        return errors.Count == 0;
    }
}