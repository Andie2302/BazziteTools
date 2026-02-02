namespace BazziteTools.builder.command.curl;

public static class Net
{
    public static CurlBuilder Download(string url) => new CurlBuilder(url);
}