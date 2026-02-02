namespace BazziteTools.builder.command.distrobox;

public class DistroboxContainer
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public bool IsRunning => Status.Contains("Up", StringComparison.OrdinalIgnoreCase);
}