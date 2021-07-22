using System.Text.Json;
using System.Text.Json.Serialization;

public static class ConfigReader
{
    public static MaybeWithError<Config, string> ReadConfig()
    {
        const string path = "texelperconfig";
        return ReadJsonFromFile(path)
            .Bind(ProcessJsonIntoConfig)
            .Bind(CheckFieldsNotNull);
    }
    private static MaybeWithError<string, string> ReadJsonFromFile(string path)
    {
        if (!System.IO.File.Exists(path))
        {
            return new ErrorWrapper<string, string>("The config file doesn't exist");
        }
        else
        {
            string json = System.IO.File.ReadAllText(path);
            return new ValueWrapper<string, string>(json);
        }
    }

    private static MaybeWithError<Config, string> ProcessJsonIntoConfig(string json)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            Config? configFromJson = JsonSerializer.Deserialize<Config>(json, options);
            if (configFromJson is null)
                return new ErrorWrapper<Config, string>("Error while parsing json");
            else
                return new ValueWrapper<Config, string>(configFromJson);
        }
        catch (System.Exception e)
        {
            return new ErrorWrapper<Config, string>("Error while parsing json:" + e.Message);
        }
    }

    private static MaybeWithError<Config, string> CheckFieldsNotNull(Config config)
    {
        if (config.SelectedFiles is null || config.SelectedDirectories is null)
            return new ErrorWrapper<Config, string>("Files and directories should both be non-null");
        else
            return new ValueWrapper<Config, string>(config);
    }
}