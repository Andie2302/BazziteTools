// See https://aka.ms/new-console-template for more information

using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;
using BazziteTools.builder.command.flatpak;

Console.WriteLine("Hello, World!");


// 1. Container erstellen (dein bestehendes Beispiel)
var createCmd = new DistroboxCreateBuilder()
    .WithLatestImage(DistroboxImage.Ubuntu)
    .UseNvidia()
    .WithName("ki")
    .Build();

// 2. In den Container gehen und einen Befehl ausführen
var enterCmd = new DistroboxEnterBuilder("ki")
    .WithCommand("nvidia-smi") // Testet deine RTX 5060 Ti im Container
    .Build();

// 3. Container löschen
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

// Erstelle den Distrobox-Befehl
var distroboxCmd = new DistroboxCreateBuilder()
    .WithName("ki-box")
    .WithLatestImage(DistroboxImage.Ubuntu)
    .Build();

// Packe ihn in flatpak-spawn, damit er auf Bazzite funktioniert
var finalCmd = new FlatpakSpawnBuilder()
    .Wrap(distroboxCmd)
    .Build();
Console.WriteLine(finalCmd);

// Ergebnis: flatpak-spawn --host distrobox create --name ki-box --image ubuntu:latest

var builder = DistroBox.Create()
    .WithName("ki-labor")
    .WithLatestImage(DistroboxImage.Ubuntu)
    .UseNvidia();

Console.WriteLine($"Generierter Befehl: {builder.Build()}");

// Führt den Befehl aus und zeigt dir live, wie Ubuntu heruntergeladen wird
await builder.ExecuteAsync();

// Beispiel: Discord via Flathub installieren
var installCmd = FlatPak.Install("com.discordapp.Discord")
    .From("flathub")
    .AssumeYes()
    .User()
    .Build();

Console.WriteLine($"Install-Befehl: {installCmd}");

// Wenn du ExecuteAsync bereits implementiert hast:
// await FlatPak.Install("com.discordapp.Discord").AssumeYes().ExecuteAsync();