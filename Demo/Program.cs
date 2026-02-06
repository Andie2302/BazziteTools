

using BazziteTools.builder.command.@base;
using BazziteTools.builder.command.@base.@static;
using BazziteTools.builder.command.distrobox;
using BazziteTools.executor;

Console.WriteLine("=== BazziteTools Integration Test ===\n");

var distrobox = new Command("distrobox")
    .Add(P.Verb("create"))
    .Add(P.LOpt("name", "development"))
    .Add(P.LFlag("nvidia"))
    .Add(P.LFlag("root"));

Console.WriteLine("Test 1 (Distrobox):");
Console.WriteLine(distrobox.Build());
Console.WriteLine();


var gpuCheck = new Command("nvidia-smi")
    .Add(P.LOpt("query-gpu", "temperature.gpu").WithSeparator("="))
    .Add(P.LOpt("format", "csv,noheader").WithSeparator("="));

Console.WriteLine("Test 2 (NVIDIA SMI):");
Console.WriteLine(gpuCheck.Build());
Console.WriteLine();


var ddBackup = new Command("sudo dd")
    .Add(P.Assign("if", "/dev/nvme0n1"))
    .Add(P.Assign("of", "/home/andreas/backup.img"))
    .Add(P.Assign("bs", "4M"));

Console.WriteLine("Test 3 (Zuweisungen):");
Console.WriteLine(ddBackup.Build());
Console.WriteLine();


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

var executor = new CommandExecutor();

var gpuTempCmd = new Command("nvidia-smi")
    .Add(P.LOpt("query-gpu", "temperature.gpu").WithSeparator("="))
    .Add(P.LOpt("format", "csv,noheader,nounits").WithSeparator("="));

Console.WriteLine($"Führe aus: {gpuTempCmd.Build()}");

string result = await executor.ExecuteAsync(gpuTempCmd);

Console.WriteLine($"Aktuelle GPU Temperatur: {result}°C");