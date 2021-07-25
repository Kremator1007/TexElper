public interface IJsonStringExtractor
{
    public Expected<string, string> Extract();
}

public class JsonStringFromConstantStringExtractor : IJsonStringExtractor
{
    public JsonStringFromConstantStringExtractor(string inputString) => InputString = inputString;
    public string InputString { get; }

    public Expected<string, string> Extract() =>
        new ValueWrapper<string, string>(InputString);
}

public class JsonStringFromFileExtractor : IJsonStringExtractor
{
    public JsonStringFromFileExtractor(string? filePath = null) =>
        FilePath = filePath ?? "texelperinput.json";

    public string FilePath { get; }

    public Expected<string, string> Extract()
    {
        return new ValueWrapper<string, string>(System.IO.File.ReadAllText(FilePath));
    }
}