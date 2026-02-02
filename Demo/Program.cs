using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.curl;
using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;
using BazziteTools.builder.command.filesystem;
using BazziteTools.builder.command.flatpak;
using BazziteTools.builder.command.hardware;
using BazziteTools.builder.command.rpmostree;
using BazziteTools.executor;

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
// System-Update durchführen
var sysUpdate = SystemHost.RpmOstree()
    .Upgrade()
    .AsRoot(); // Statt .WithSudo()

// Paket installieren
var installGit = SystemHost.RpmOstree()
    .Install("git")
    .AsRoot();

// Validierung und Ausgabe
var report2 = installGit.Validate();
if(report2.IsSuccess) 
{
    Console.WriteLine($"Befehl: {installGit.Build()}");
}

// Einen Ordner mit Sudo erstellen und ein Skript darin ausführbar machen
var setupScript = FileSystem.CreateDirectory("/usr/local/bin/mytool").CreateParents().AsRoot();
var makeExec = FileSystem.ChangePermissions("/usr/local/bin/mytool/run.sh").MakeExecutable().AsRoot();

Console.WriteLine(setupScript.Build());
Console.WriteLine(makeExec.Build());



// 1. GPU Check ausführen
var gpuCheck = new NvidiaSmiBuilder().QueryTemperature();
var result = await CommandExecutor.ExecuteAsync(gpuCheck); // Jetzt ist result nicht mehr void

// 2. Variable vorab deklarieren
int temp = 0; 

if (result.Success && int.TryParse(result.Output, out temp))
{
    Console.WriteLine($"\n🔥 Aktuelle GPU Temperatur: {temp}°C");
    if (temp > 80) Console.WriteLine("⚠️ Ganz schön heiß hier!");
}
else if (!result.Success)
{
    Console.WriteLine("Fehler beim Auslesen der GPU Daten.");
}

// 1. Liste abfragen
var listCmd = DistroBox.List();
var result = await CommandExecutor.ExecuteAsync(listCmd);

if (result.Success)
{
    var containers = new List<DistroboxContainer>();
    
    // Distrobox CSV überspringen (Header) und Zeilen splitten
    var lines = result.Output.Split('\n').Skip(1); 

    foreach (var line in lines)
    {
        var parts = line.Split('|').Select(p => p.Trim('"')).ToArray();
        if (parts.Length >= 4)
        {
            containers.Add(new DistroboxContainer {
                Id = parts[0],
                Name = parts[1],
                Status = parts[2],
                Image = parts[3]
            });
        }
    }

    // 2. Mit den Daten arbeiten
    Console.WriteLine($"\n📦 Gefundene Container: {containers.Count}");
    foreach (var c in containers)
    {
        var icon = c.IsRunning ? "🟢" : "🔴";
        Console.WriteLine($"{icon} {c.Name} ({c.Image})");
    }
}