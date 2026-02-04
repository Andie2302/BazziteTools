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

    public override CommandReport Validate()
    {
        var report = new CommandReport();
        var hasName = Arguments.Any(a => a.StartsWith("--name"));
        var hasImage = Arguments.Any(a => a.StartsWith("--image"));

        if (!hasName) report.AddError("Ein Container-Name muss mit .WithName() angegeben werden.");
        if (!hasImage) report.AddError("Ein Image muss mit .WithImage() angegeben werden.");
        var wantsNvidia = Arguments.Contains("--nvidia");

        if (wantsNvidia && !PlatformEnvironment.IsNvidiaDriverLoaded)
        {
            report.AddError("NVIDIA-Unterstützung wurde angefordert, aber der NVIDIA-Treiber wurde auf dem Host-System nicht gefunden.");
        }

        return report;
    }
    
    public DistroboxCreateBuilder WithPackages(params string[] packages)
    {
        if (packages.Length > 0)
        {
            AddLongOption("additional-packages", string.Join(" ", packages));
        }
        return this;
    }
    public DistroboxCreateBuilder WithInitScript(string scriptPath)
    {
        AddLongOption("init-hooks", scriptPath);
        return this;
    }
}