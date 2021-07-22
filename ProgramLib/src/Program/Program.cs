using System;
using Serilog;
public class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates()
    {
        FilesSelector = new FilesByDirectoriesSelector(new UserAskedDirectoriesSelector());
        BackendFileComparer = new BasicFileComparer(new ByLevenshteinProblemComparer());
        Printer = new DefaultPrinter();
    }
    public ResultData RunProgram()
    {
        DealWithConfigFile();
        InitLogger();
        var inputData = FilesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = BackendFileComparer.CompareFiles(inputData);
        Printer.Display(resultData);
        return resultData;
    }

    private void DealWithConfigFile()
    {
        var config = ConfigReader.ReadConfig();
        config.CallIfHasValue(SelectFilesFromConfig);

        if (config is ErrorWrapper<Config, string> errorWrapper)
            Console.WriteLine(errorWrapper.Error);
    }
    private void SelectFilesFromConfig(Config config)
    {
        FilesSelector = new FilesFromConfigSelector(config);
    }


    private static void InitLogger()
    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File("log.txt")
            .CreateLogger();
    }

    public IFilesSelector FilesSelector { get; private set; }
    private IBackendFileComparer BackendFileComparer { get; }
    private IPrettyPrinter Printer { get; }
}
