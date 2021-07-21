using System.Text.Json;
class ConfigReader
{
    public static MaybeWithError<Config, string> ReadConfig()
    {
        string path = "texelperconfig";
        return ReadJsonFromFile(path)
            .Bind(ProcessJsonIntoConfig)
            .Bind(CheckFieldsNotNull);
    }
    private static MaybeWithError<string, string> ReadJsonFromFile(string path)
    {
        if (!System.IO.File.Exists(path))
            return new ErrorWrapper<string, string>("The config file doesn't exist");
        else
        {
            string json = System.IO.File.ReadAllText(path);
            return new ValueWrapper<string, string>(json);
        }
    }

    private static MaybeWithError<Config, string> ProcessJsonIntoConfig(string json)
    {
        Config? configFromJson = JsonSerializer.Deserialize<Config>(json);
        if (configFromJson is null)
            return new ErrorWrapper<Config, string>("Error while parsing json");
        else
            return new ValueWrapper<Config, string>(configFromJson);
    }

    private static MaybeWithError<Config, string> CheckFieldsNotNull(Config config)
    {
        if (config.SelectedFiles is null || config.SelectedDirectories is null)
            return new ErrorWrapper<Config, string>("Files and directories should both be non-null");
        else
            return new ValueWrapper<Config, string>(config);
    }
}