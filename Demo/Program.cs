// See https://aka.ms/new-console-template for more information

using BazziteTools;
using BazziteTools.builder.command.distrobox;
using BazziteTools.builder.command.distrobox.images;

Console.WriteLine("Hello, World!");

DistroboxCreateBuilder builder = new();
builder.WithLatestImage(DistroboxImage.Ubuntu);
builder.UseNvidia();
builder.WithName("ki");
var x = builder.Build();
Console.WriteLine(x);