using BazziteTools.command.@base.builder;
using BazziteTools.command.@base.builder.@static;

namespace BazziteTools.command.distrobox;

public class DistroboxCreate
{
    private readonly Command _command = new("distrobox-create");

    /// <summary>
    /// Setzt den Namen des Containers (--name).
    /// </summary>
    public DistroboxCreate WithName(string name)
    {
        var opt = P.LongOption("name");
        opt.Value = name; // Zuweisung an das Property
        _command.Add(opt);
        return this;
    }

    /// <summary>
    /// Setzt das Image für den Container (--image).
    /// </summary>
    public DistroboxCreate FromImage(string image)
    {
        var opt = P.LongOption("image");
        opt.Value = image; // Zuweisung an das Property
        _command.Add(opt);
        return this;
    }

    /// <summary>
    /// Erstellt einen Root-Container (--root).
    /// </summary>
    public DistroboxCreate AsRoot()
    {
        _command.Add(P.LongFlag("root"));
        return this;
    }

    /// <summary>
    /// Überspringt die Bestätigungsabfragen (--yes).
    /// </summary>
    public DistroboxCreate ForceYes()
    {
        _command.Add(P.LongFlag("yes"));
        return this;
    }

    /// <summary>
    /// Fügt zusätzliche Pakete hinzu (--additional-packages).
    /// </summary>
    public DistroboxCreate WithAdditionalPackages(params string[] packages)
    {
        if (packages.Length > 0)
        {
            var opt = P.LongOption("additional-packages");
            opt.Value = string.Join(" ", packages); // Zuweisung an das Property
            _command.Add(opt);
        }
        return this;
    }

    /// <summary>
    /// Erstellt das finale Kommando-Objekt.
    /// </summary>
    public Command Build() => _command;

    public override string ToString() => _command.Build();
}