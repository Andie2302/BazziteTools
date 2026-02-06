
using BazziteTools;
using BazziteTools.check;
using BazziteTools.command;

Console.WriteLine("Hello, World!");


// Test 1: Ein komplexer Distrobox-Befehl (Verb + LongOptions + Flags)
var distrobox = new CommandBuilder("distrobox")
    .Add(P.Verb("create"))
    .Add(P.LongOption("name", "ki-box"))
    .Add(P.LongOption("image", "ubuntu:22.04"))
    .Add(P.Flag("nvidia"))
    .Add(P.Flag("v"));

Console.WriteLine("--- Distrobox Test ---");
Console.WriteLine(distrobox.Build());
// Erwartet: distrobox create --name ki-box --image ubuntu:22.04 -nvidia -v
// Hinweis: Falls nvidia ein LongFlag sein soll, nutzt du P.LongOption("nvidia", "") 
// oder wir müssten P.LongFlag hinzufügen.


// Test 2: Ein Zuweisungs-Befehl (z.B. für Pfade oder dd)
var ddCommand = new CommandBuilder("sudo dd")
    .Add(P.Assign("if", "/dev/nvme0n1"))
    .Add(P.Assign("of", "/home/andreas/backup.img"))
    .Add(P.Assign("bs", "4M"));

Console.WriteLine("\n--- Zuweisung (Assign) Test ---");
Console.WriteLine(ddCommand.Build());
// Erwartet: sudo dd if=/dev/nvme0n1 of=/home/andreas/backup.img bs=4M


// Test 3: Hardware-Abfrage für deine RTX 5060 Ti
var gpuTemp = new CommandBuilder("nvidia-smi")
    .Add(P.LongOption("query-gpu", "temperature.gpu"))
    .Add(P.LongOption("format", "csv,noheader"));

Console.WriteLine("\n--- NVIDIA GPU Temp Test ---");
Console.WriteLine(gpuTemp.Build());
// Erwartet: nvidia-smi --query-gpu temperature.gpu --format csv,noheader


// Test 4: Mischen von manuellen CommandParameters und P-Klasse (Der "Spagat")
var custom = new CommandBuilder("flatpak")
    .Add(P.Verb("install"))
    .Add(new CommandParameter()
        .WithPrefix("--")
        .WithName("user")
        .WithPostfix("!") // Nur als Beispiel für die Flexibilität
        .WithSeparator(":"))
    .Add(P.Argument("flathub"));

Console.WriteLine("\n--- Custom Flexibilität Test ---");
Console.WriteLine(custom.Build());

/*

using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;



const string name = "ki";
var home = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"distroboxes",name);

var distrobox = DistroBox.Create().WithName(name).WithHome(home).WithLatestImage(DistroboxImage.Ubuntu).UseNvidia();

distrobox.WithPackages("python3", "python3-pip","zstd","nano","nodejs","npm");

Console.WriteLine(distrobox.Build());

//curl -fsSL https://ollama.com/install.sh | sh
//pip install open-webui --break-system-packages
//curl -fsSL https://openclaw.ai/install.sh | bash
//sudo npm install -g openclaw

//curl -fsSL https://ollama.com/install.sh | sh
//pip install open-webui --break-system-packages
//sudo npm install -g openclaw

//*/