namespace BazziteTools.builder.command.distrobox.images;

public static class DistroboxImageExtensions
{
    public static string ToImageString(this DistroboxImage image) => image switch
    {
        DistroboxImage.Ubuntu => "ubuntu:latest",
        DistroboxImage.Fedora => "fedora:latest",
        DistroboxImage.Arch   => "archlinux:latest",
        DistroboxImage.Alpine => "alpine:latest",
        DistroboxImage.Debian => "debian:stable",
        _ => throw new ArgumentOutOfRangeException(nameof(image), image, null)
    };
}