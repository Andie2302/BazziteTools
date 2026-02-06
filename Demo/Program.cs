

using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.distrobox;

Console.WriteLine("=== BazziteTools Integration Test ===\n");

// 1. Test: Ein klassischer Distrobox-Befehl
// Erwartet: distrobox create --name development --nvidia --root
var distrobox = new Command("distrobox")
    .Add(P.Verb("create"))
    .Add(P.LOpt("name", "development"))
    .Add(P.LFlag("nvidia"))
    .Add(P.LFlag("root"));

Console.WriteLine("Test 1 (Distrobox):");
Console.WriteLine(distrobox.Build());
Console.WriteLine();


// 2. Test: Hardware-Abfrage deiner NVIDIA RTX 5060 Ti
// Erwartet: nvidia-smi --query-gpu=temperature.gpu --format=csv,noheader
// Hier nutzen wir .WithSeparator("="), falls nvidia-smi das benötigt
var gpuCheck = new Command("nvidia-smi")
    .Add(P.LOpt("query-gpu", "temperature.gpu").WithSeparator("="))
    .Add(P.LOpt("format", "csv,noheader").WithSeparator("="));

Console.WriteLine("Test 2 (NVIDIA SMI):");
Console.WriteLine(gpuCheck.Build());
Console.WriteLine();


// 3. Test: System-nahe Zuweisungen (wie dd oder Pfade)
// Erwartet: sudo dd if=/dev/nvme0n1 of=/home/andreas/backup.img bs=4M
var ddBackup = new Command("sudo dd")
    .Add(P.Assign("if", "/dev/nvme0n1"))
    .Add(P.Assign("of", "/home/andreas/backup.img"))
    .Add(P.Assign("bs", "4M"));

Console.WriteLine("Test 3 (Zuweisungen):");
Console.WriteLine(ddBackup.Build());
Console.WriteLine();


// 4. Test: Flatpak mit speziellen Suffixen (Fluent-Check)
// Erwartet: flatpak install --user! flathub
var flatpak = new Command("flatpak")
    .Add(P.Verb("install"))
    .Add(P.LFlag("user").WithSuffix("!"))
    .Add(P.Arg("flathub"));

Console.WriteLine("Test 4 (Fluent & Suffix):");
Console.WriteLine(flatpak.Build());


var assemble = new DistroboxAssembleCommand()
    .Create()
    .WithFile("./distrobox.ini")
    .Replace();

Console.WriteLine(assemble.Build());
// Erwartet: distrobox assemble create --file ./distrobox.ini --replace