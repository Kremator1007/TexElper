public class Config
{
    public LogVerbosity LogVerbosity { get; init; } = LogVerbosity.Information;
    public string[] SelectedDirectories { get; init; } = System.Array.Empty<string>();
    public string[] SelectedFiles { get; init; } = System.Array.Empty<string>();
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