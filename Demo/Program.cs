using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;
using BazziteTools.builder.command.filesystem;
using BazziteTools.executor;

Console.WriteLine("Hello, World!");

var name = "ki";
var home = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"distroboxes",name);

var distrobox = DistroBox.Create().WithName(name).WithHome(home).WithLatestImage(DistroboxImage.Ubuntu).UseNvidia().Build();

Console.WriteLine(distrobox);

var setup = FileSystemWorkflows.PrepareAdminFolder("/tmp/mytool", "username");
await CommandExecutor.ExecuteAsync(setup);

