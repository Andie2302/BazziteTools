using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;

Console.WriteLine("Hello, World!");

var name = "ki";
var home = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"distroboxes",name);

var distrobox = DistroBox.Create().WithName(name).WithHome(home).WithLatestImage(DistroboxImage.Ubuntu).UseNvidia().Build();

Console.WriteLine(distrobox);
