
Console.WriteLine("Hello, World!");

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