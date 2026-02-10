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
        // In KeyValueParameter.cs heißt die Methode .Value(string value)
        _command.Add(P.LongOption("name").Value(name));
        return this;
    }

    /// <summary>
    /// Setzt das Image für den Container (--image).
    /// </summary>
    public DistroboxCreate FromImage(string image)
    {
        _command.Add(P.LongOption("image").Value(image));
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
            _command.Add(P.LongOption("additional-packages").Value(string.Join(" ", packages)));
        }
        return this;
    }

    /// <summary>
    /// Erstellt das finale Kommando-Objekt.
    /// </summary>
    public Command Build() => _command;

    public override string ToString() => _command.Build();
}