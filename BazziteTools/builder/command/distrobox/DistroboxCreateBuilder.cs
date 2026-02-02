using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.distrobox.images;
using BazziteTools.builder.command.flatpak;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxCreateBuilder : LinuxCommandBuilder<DistroboxCreateBuilder>
{
    public DistroboxCreateBuilder() : base("distrobox") => AddArgument("create");

    public DistroboxCreateBuilder WithImage(string image)
    {
        AddLongOption("image", image);
        return this;
    }

    public DistroboxCreateBuilder WithLatestImage(DistroboxImage image) => WithImage(image.ToImageString());

    public DistroboxCreateBuilder UseNvidia()
    {
        AddLongOption("nvidia");
        return this;
    }

    public DistroboxCreateBuilder WithHome(string path)
    {
        AddLongOption("home", path);
        return this;
    }

    public DistroboxCreateBuilder WithName(string distroboxName)
    {
        AddLongOption("name", distroboxName);
        return this;
    }
    
    public override bool IsValid(out List<string> errors)
    {
        errors = [];
    
        // Wir prüfen, ob die Tokens in der internen Liste vorhanden sind
        // Da wir die Argumente über AddLongOption hinzufügen, suchen wir nach den Flags
        var hasName = _arguments.Any(a => a.StartsWith("--name"));
        var hasImage = _arguments.Any(a => a.StartsWith("--image"));

        if (!hasName) errors.Add("Ein Container-Name muss mit .WithName() angegeben werden.");
        if (!hasImage) errors.Add("Ein Image muss mit .WithImage() angegeben werden.");
        var wantsNvidia = _arguments.Contains("--nvidia");

        if (wantsNvidia && !PlatformEnvironment.IsNvidiaDriverLoaded)
        {
            errors.Add("NVIDIA-Unterstützung wurde angefordert, aber der NVIDIA-Treiber wurde auf dem Host-System nicht gefunden.");
        }

        return errors.Count == 0;
    }
    
}