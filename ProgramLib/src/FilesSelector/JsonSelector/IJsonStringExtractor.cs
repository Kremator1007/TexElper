public interface IJsonStringExtractor
{
    public string Extract();
}

public class JsonStringFromConstantStringExtractor : IJsonStringExtractor
{
    public JsonStringFromConstantStringExtractor(string inputString) => InputString = inputString;
    public string InputString { get; }

    public string Extract() => InputString;
}

public class JsonStringFromFileExtractor : IJsonStringExtractor
{
    public JsonStringFromFileExtractor(string? filePath = null) =>
        FilePath = filePath ?? "texelperinput.json";

    public string FilePath { get; }

    public string Extract()
    {
        return System.IO.File.ReadAllText(FilePath);
    }
}