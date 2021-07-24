using System;
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
        Config? config = DealWithConfigFile();
        LogHandler.InitGlobalLog(config);
        var inputData = FilesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = BackendFileComparer.CompareFiles(inputData);
        Printer.Display(resultData);
        return resultData;
    }

    private Config? DealWithConfigFile()
    {
        var config = ConfigReader.ReadConfig();
        config.CallIfHasValue(UseConfigAsFileSelector);

        if (config is ErrorWrapper<Config, string> errorWrapper)
            Console.WriteLine(errorWrapper.Error);
        return config.Extract();
    }
    private void UseConfigAsFileSelector(Config config)
    {
        FilesSelector = new FilesFromConfigSelector(config);
    }

    public IFilesSelector FilesSelector { get; private set; }
    private IBackendFileComparer BackendFileComparer { get; }
    private IPrettyPrinter Printer { get; }
}
