// See https://aka.ms/new-console-template for more information

using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;

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

Console.WriteLine($"Create: {createCmd}");
Console.WriteLine($"Enter:  {enterCmd}");
Console.WriteLine($"Remove: {rmCmd}");