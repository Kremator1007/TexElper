public class Config
{
    public LogVerbosity LogVerbosity { get; init; } = LogVerbosity.Information;
    public string[]? SelectedDirectories { get; init; }
    public string[]? SelectedFiles { get; init; }
}

public enum LogVerbosity
{
    Verbose,
    Debug,
    Information,
    Warning,
    Error,
    Fatal
}