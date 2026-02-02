using System.Diagnostics;

namespace BazziteTools;

public class DistroboxBuilder
{
    private readonly List<string> _args = [];

    public DistroboxBuilder Create(string imageName, string containerName)
    {
        _args.Add("create");
        _args.Add("--image");
        _args.Add(imageName);
        _args.Add("--name");
        _args.Add(containerName);
        return this;
    }

    public DistroboxBuilder WithHome(string path)
    {
        _args.Add("--home");
        _args.Add(path);
        return this;
    }

    public DistroboxBuilder UseNvidia()
    {
        _args.Add("--nvidia");
        return this;
    }

    public DistroboxBuilder WithPackages(params string[] packages)
    {
        if (packages.Length > 0)
        {
            _args.Add("--additional-packages");
            _args.Add($"\"{string.Join(" ", packages)}\"");
        }
        return this;
    }

    public string Build() => $"distrobox {string.Join(" ", _args)}";

    public void Execute()
    {
        var command = Build();
        var psi = new ProcessStartInfo
        {
            FileName = "/usr/bin/distrobox", // Vollständiger Pfad ist auf Bazzite sicherer
            Arguments = string.Join(" ", _args),
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi);
        process?.WaitForExit();
    }
}