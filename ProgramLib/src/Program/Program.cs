using System;
using Serilog;
public class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates()
    {
        filesSelector = new FilesByDirectoriesSelector(new UserAskedDirectoriesSelector());
        backendFileComparer = new BasicFileComparer(new ByLevenshteinProblemComparer());
        printer = new DefaultPrinter();
    }
    public ResultData RunProgram()
    {
        var config = ConfigReader.ReadConfig();
        if (config is ErrorWrapper<Config, string> errorWrapper)
            Console.WriteLine(errorWrapper.Error);
        InitLogger();
        var inputData = filesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = backendFileComparer.CompareFiles(inputData);
        printer.Display(resultData);
        return resultData;
    }

    private static void InitLogger()
    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.File("log.txt")
            .CreateLogger();
    }

    private readonly IFilesSelector filesSelector;
    private readonly IBackendFileComparer backendFileComparer;
    private readonly IPrettyPrinter printer;
}
