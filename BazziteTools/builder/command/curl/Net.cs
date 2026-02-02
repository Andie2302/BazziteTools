namespace BazziteTools.builder.command.curl;

public static class Net
{
    public static CurlBuilderBuilder Download(string url) => new CurlBuilderBuilder(url);
}