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
        try
        {
            return new ValueWrapper<string, string>(System.IO.File.ReadAllText(FilePath));
        }
        catch (System.Exception)
        {
            return new ErrorWrapper<string, string>("Error while opening file texlper.json (it probably doesn't exist)");
        }
    }
}