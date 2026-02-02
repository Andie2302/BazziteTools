using BazziteTools.builder.command.distrobox.images;

namespace BazziteTools.builder.command.distrobox;

public class DistroboxCreateBuilder : LinuxCommandBuilder
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
}