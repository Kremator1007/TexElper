public class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates()
    {
        LogHandler.InitGlobalLog();
        FilesSelector = new FromJsonSelector(new JsonStringFromFileExtractor());
        BackendFileComparer = new BasicFileComparer(new ByLevenshteinProblemComparer());
        Printer = new DefaultPrinter(new System.IO.StreamWriter("out.txt"));
    }

    public ResultData RunProgram()
    {
        var inputData = FilesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = BackendFileComparer.CompareFiles(inputData);
        Printer.Display(resultData);
        return resultData;
    }

    public IFilesSelector FilesSelector { get; }
    private IBackendFileComparer BackendFileComparer { get; }
    private IPrettyPrinter Printer { get; }
}
