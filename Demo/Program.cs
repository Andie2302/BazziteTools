using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.curl;
using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;

Console.WriteLine("Hello, World!");

const string DefaultBoxName = "ki";
const string InstallerUrl = "https://openclaw.ai/install.sh";

var createCmd = new DistroboxCreateBuilder()
    .WithLatestImage(DistroboxImage.Ubuntu)
    .UseNvidia()
    .WithName(DefaultBoxName)
    .Build();
var enterCmd = new DistroboxEnterBuilder(DefaultBoxName)
    .WithCommand("nvidia-smi")
    .Build();
var rmCmd = new DistroboxRemoveBuilder(DefaultBoxName)
    .Force()
    .Build();
// ... existing code ...
var installerCmd = Net.Download(InstallerUrl)
    .Fail()
    .Silent()
    .ShowError()
    .FollowLocation()
    .Build();
// Das Resultat ist: curl https://openclaw.ai/install.sh --fail --silent --show-error --location
// (Die Reihenfolge der Argumente spielt bei curl meist keine Rolle)
var finalShellCommand = $"{installerCmd} | bash";
Console.WriteLine(finalShellCommand);


// 1. Curl-Teil bauen
var curl = new CurlBuilder(InstallerUrl)
    .ForInstallation();
// 2. Bash-Teil bauen (Generic)
var bash = new GenericCommandBuilder("bash");
// 3. Pipeline erstellen
// Statt manuell die Pipeline zu bauen, nutzt du einfach PipeTo:
var pipeline = curl.PipeTo(bash);
Console.WriteLine($"Pipeline-Befehl: {pipeline.Build()}");
var distroboxCmdBuilt = DistroBox.Create().Build();
Console.WriteLine($"Distrobox-Befehl: {distroboxCmdBuilt}");