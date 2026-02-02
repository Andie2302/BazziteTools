namespace BazziteTools.builder.command.@base;

public class CommandReport
{
    private readonly List<string> _errors = [];
    private readonly List<string> _warnings = [];

    public void AddError(string text) => _errors.Add(text);
    public void AddWarning(string text) => _warnings.Add(text);

    public IReadOnlyList<string> Errors => _errors;
    public IReadOnlyList<string> Warnings => _warnings;

    public bool IsSuccess => _errors.Count == 0;
    public bool HasWarnings => _warnings.Count > 0;

    public void AddErrors(IReadOnlyList<string> errorMessages)
    {
        _errors.AddRange(errorMessages);
    }
    public void AddWarnings(IReadOnlyList<string> warningMessages)
    {
        _warnings.AddRange(warningMessages);
    }
}