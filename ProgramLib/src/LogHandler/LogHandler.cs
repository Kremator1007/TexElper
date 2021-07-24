using Serilog;
using System;
using System.Linq;

internal static class LogHandler
{
    public static void InitGlobalLog(Config? config) => Serilog.Log.Logger = new LoggerConfiguration()
            .SetMinimumLevel(config?.LogVerbosity)
            .SetupLogFile()
            .CreateLogger();

    private static readonly string supposedLogsFolder = new Func<string>(() =>
    {
        string localappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string logsFolder = System.IO.Path.Combine(localappdata, "TexElper/logs");
        return logsFolder;
    })();
    private static readonly int maximumLogFilesAmount = 10;

    private static LoggerConfiguration SetMinimumLevel(this LoggerConfiguration loggerConfiguration, LogVerbosity? logVerbosity) =>
        logVerbosity switch
        {
            null => loggerConfiguration.MinimumLevel.Information(),
            LogVerbosity.Verbose => loggerConfiguration.MinimumLevel.Verbose(),
            LogVerbosity.Debug => loggerConfiguration.MinimumLevel.Debug(),
            LogVerbosity.Information => loggerConfiguration.MinimumLevel.Information(),
            LogVerbosity.Warning => loggerConfiguration.MinimumLevel.Warning(),
            LogVerbosity.Error => loggerConfiguration.MinimumLevel.Error(),
            LogVerbosity.Fatal => loggerConfiguration.MinimumLevel.Fatal(),
            _ => throw new System.Exception("unreachable")
        };

    private static LoggerConfiguration SetupLogFile(this LoggerConfiguration loggerConfiguration)
    {
        CreateLogFolderIfDoesntExist();
        string currentLogFile = CreateCurrentLogFile();
        DeleteTheOldestLogIfNecessary();
        return loggerConfiguration.WriteTo.File(currentLogFile);
    }


    private static void CreateLogFolderIfDoesntExist()
    {
        System.IO.Directory.CreateDirectory(supposedLogsFolder);
    }


    private static string CreateCurrentLogFile()
    {
        string logFileNameWithoutExtension = System.DateTime.Now
            .ToUniversalTime()
            .ToString("dd MMMM yyyy, HH_mm_ss");
        while (System.IO.File.Exists(System.IO.Path.Combine(supposedLogsFolder, logFileNameWithoutExtension)))
        {
            logFileNameWithoutExtension += "_";
        }
        string path = System.IO.Path.Combine(supposedLogsFolder, logFileNameWithoutExtension + ".log");
        System.IO.File.Create(path).Close();
        return path;
    }
    private static void DeleteTheOldestLogIfNecessary()
    {
        var logFiles = System.IO.Directory.EnumerateFiles(supposedLogsFolder);
        if (logFiles.Count() > maximumLogFilesAmount)
        {
            string oldestFile = logFiles.OrderBy(fileName => new System.IO.FileInfo(fileName).CreationTimeUtc).First();
            System.IO.File.Delete(oldestFile);
        }
    }
}