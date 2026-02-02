using BazziteTools.builder.command.@base;

namespace BazziteTools.builder.command.filesystem;

public class ChownBuilder : LinuxCommandBuilder<ChownBuilder>
{
    private readonly string _path;

    public ChownBuilder(string path) : base("chown")
    {
        _path = path;
    }

    public ChownBuilder ToUser(string user)
    {
        AddArgument(user);
        return this;
    }

    public ChownBuilder Recursive() => AddShortOption('R');

    public override string Build() => $"{base.Build()} {_path}";

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        if (string.IsNullOrEmpty(_path)) report.AddError("Kein Pfad für chown angegeben.");
        if (Arguments.All(a => a.StartsWith("-"))) report.AddError("Kein Benutzer angegeben.");
        return report;
    }
    
    public ChownBuilder ToCurrentUser()
    {
        AddArgument(Environment.UserName);
        return this;
    }
    
}