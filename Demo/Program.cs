using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.curl;
using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;
using BazziteTools.builder.command.flatpak;
using BazziteTools.builder.command.rpmostree;

Console.WriteLine("Hello, World!");


var createCmd = new DistroboxCreateBuilder()
    .WithLatestImage(DistroboxImage.Ubuntu)
    .UseNvidia()
    .WithName("ki")
    .Build();

var enterCmd = new DistroboxEnterBuilder("ki")
    .WithCommand("nvidia-smi")
    .Build();

var rmCmd = new DistroboxRemoveBuilder("ki")
    .Force()
    .Build();

var upgradeCmd = DistroBox.Upgrade().All().Build();

var assembleCmd = DistroBox.Assemble().Create().Build();

Console.WriteLine($"Create: {createCmd}");
Console.WriteLine($"Enter:  {enterCmd}");
Console.WriteLine($"Remove: {rmCmd}");
Console.WriteLine($"Upgrade: {upgradeCmd}");
Console.WriteLine($"Assemble: {assembleCmd}");

var distroboxCmd = new DistroboxCreateBuilder()
    .WithName("ki-box")
    .WithLatestImage(DistroboxImage.Ubuntu)
    .Build();

var finalCmd = new FlatpakSpawnBuilder()
    .Wrap(distroboxCmd)
    .Build();
Console.WriteLine(finalCmd);

var builder = DistroBox.Create()
    .WithName("ki-labor")
    .WithLatestImage(DistroboxImage.Ubuntu)
    .UseNvidia();

Console.WriteLine($"Generierter Befehl: {builder.Build()}");

var installCmd = FlatPak.Install("com.discordapp.Discord")
    .From("flathub")
    .AssumeYes()
    .User()
    .Build();

Console.WriteLine($"Install-Befehl: {installCmd}");


var installerCmd = Net.Download("https://openclaw.ai/install.sh")
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
var curl = new CurlBuilder("https://openclaw.ai/install.sh")
    .ForInstallation();

// 2. Bash-Teil bauen (Generic)
var bash = new GenericCommandBuilder("bash");

// 3. Pipeline erstellen

// Statt manuell die Pipeline zu bauen, nutzt du einfach PipeTo:
var pipeline = new CurlBuilder("https://openclaw.ai/install.sh")
    .ForInstallation()
    .PipeTo(new GenericCommandBuilder("bash"));
Console.WriteLine($"Pipeline-Befehl: {pipeline.Build()}");

var xxx=DistroBox.Create().Build();
Console.WriteLine($"Distrobox-Befehl: {xxx}");


var badBuilder = DistroBox.Create(); // Name und Image fehlen!

var report = badBuilder.Validate();

if (!report.IsSuccess)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("❌ Fehler im Befehl:");
    foreach (var error in report.Errors) Console.WriteLine($"   - {error}");
}

if (report.HasWarnings)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("⚠️  Warnungen:");
    foreach (var warning in report.Warnings) Console.WriteLine($"   - {warning}");
}

Console.ResetColor();

// Ein rpm-ostree upgrade mit sudo
var upgradeCommand = new RpmOstreeBuilder()
    .Upgrade()
    .WithSudo(); // Hier wird der SudoBuilder drumherum gewickelt

Console.WriteLine($"Update-Befehl: {upgradeCommand.Build()}");
// Ergibt: sudo rpm-ostree upgrade