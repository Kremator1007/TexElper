using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class FromJsonSelector : IFilesSelector
{
    public FromJsonSelector(IJsonStringExtractor stringExtractor) =>
        JsonStringExtractor = stringExtractor;

    public FilesToCompare SelectFilesForFindingSimilarProblems()
    {
        string extractedJsonString = JsonStringExtractor.Extract();
        JsonTemplateData jsonData = ParseJsonData(extractedJsonString);
        return ExtractFilesList(jsonData);
    }

    public IJsonStringExtractor JsonStringExtractor { get; init; }

    private static JsonTemplateData ParseJsonData(string extractedJsonString)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
        };
        JsonTemplateData? jsonData = JsonSerializer.Deserialize<JsonTemplateData>(
            extractedJsonString, options);
        return jsonData!;
    }

    private static FilesToCompare ExtractFilesList(JsonTemplateData jsonData)
    {
        List<string> filesList = new();

        ExtractFilesFromConfigDirectories(filesList, jsonData);
        ExtractFilesFromConfigFilesList(filesList, jsonData);

        return new FilesToCompare(filesList);
    }

    private static void ExtractFilesFromConfigFilesList(List<string> filesList, JsonTemplateData jsonData)
    {
        Serilog.Log.Logger.Verbose("Extracting files from config's files list");
        string[] extractedFiles = jsonData.SelectedFiles.Where(
                    System.IO.File.Exists
                    ).ToArray();
        string logFileList = string.Join('\n', extractedFiles);
        Serilog.Log.Logger.Verbose("The following files were successfuly extracted:\n" + logFileList);
        filesList.AddRange(extractedFiles);
    }

    private static void ExtractFilesFromConfigDirectories(List<string> filesList, JsonTemplateData jsonData)
    {
        IDirectoriesSelector dirSelector = new ConstantDirectoriesSelector(
            jsonData.SelectedDirectories);
        var filesFromDirectories = new FilesByDirectoriesSelector(dirSelector)
            .SelectFilesForFindingSimilarProblems();
        filesList.AddRange(filesFromDirectories.AllRelevantFiles);
    }
}