using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.distrobox.images;
using BazziteTools.builder.command.flatpak;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxCreateBuilderBuilder : LinuxCommandBuilderBuilder<DistroboxCreateBuilderBuilder>
{
    public DistroboxCreateBuilderBuilder() : base("distrobox") => AddArgument("create");

    public DistroboxCreateBuilderBuilder WithImage(string image)
    {
        AddLongOption("image", image);
        return this;
    }

    public DistroboxCreateBuilderBuilder WithLatestImage(DistroboxImage image) => WithImage(image.ToImageString());

    public DistroboxCreateBuilderBuilder UseNvidia()
    {
        AddLongOption("nvidia");
        return this;
    }

    public DistroboxCreateBuilderBuilder WithHome(string path)
    {
        AddLongOption("home", path);
        return this;
    }

    public DistroboxCreateBuilderBuilder WithName(string distroboxName)
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
}