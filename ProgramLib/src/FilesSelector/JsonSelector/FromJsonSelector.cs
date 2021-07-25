using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class FromJsonSelector : IFilesSelector
{
    public FromJsonSelector(IJsonStringExtractor stringExtractor) =>
        JsonStringExtractor = stringExtractor;

    public Expected<FilesToCompare, string> SelectFilesForFindingSimilarProblems()
    {
        return JsonStringExtractor
            .Extract()
            .Bind(ParseJsonData)
            .Bind(ExtractFilesList);
    }

    public IJsonStringExtractor JsonStringExtractor { get; init; }

    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    private static Expected<JsonTemplateData, string> ParseJsonData(string extractedJsonString)
    {
        try
        {
            JsonTemplateData? jsonData = JsonSerializer.Deserialize<JsonTemplateData>(
                extractedJsonString, Options);
            if (jsonData is not null)
            {
                return new ValueWrapper<JsonTemplateData, string>(jsonData!);
            }
            else
            {
                return new ErrorWrapper<JsonTemplateData, string>(
                   "Json Deserializer interpreted data as null");
            }
        }
        catch (System.Exception e)
        {
            return new ErrorWrapper<JsonTemplateData, string>("Error while parsing json: " + e.Message);
        }
    }

    private static Expected<FilesToCompare, string> ExtractFilesList(JsonTemplateData jsonData)
    {
        List<string> filesList = new();

        ExtractFilesFromInputDirectories(filesList, jsonData);
        ExtractFilesFromInputFilesList(filesList, jsonData);

        return new ValueWrapper<FilesToCompare, string>(new FilesToCompare(filesList));
    }

    private static void ExtractFilesFromInputFilesList(List<string> filesList, JsonTemplateData jsonData)
    {
        Serilog.Log.Logger.Verbose("Extracting files from config's files list");
        string[] extractedFiles = jsonData.SelectedFiles.Where(
                    System.IO.File.Exists
                    ).ToArray();
        string logFileList = string.Join('\n', extractedFiles);
        Serilog.Log.Logger.Verbose("The following files were successfuly extracted:\n" + logFileList);
        filesList.AddRange(extractedFiles);
    }

    private static void ExtractFilesFromInputDirectories(List<string> filesList, JsonTemplateData jsonData)
    {
        IDirectoriesSelector dirSelector = new ConstantDirectoriesSelector(
            jsonData.SelectedDirectories);
        var filesFromDirectories = new FilesByDirectoriesSelector(dirSelector)
            .SelectFilesForFindingSimilarProblems();
        System.Diagnostics.Debug.Assert(filesFromDirectories.Extract() != null);
        filesList.AddRange(filesFromDirectories.Extract()!.AllRelevantFiles);
    }
}