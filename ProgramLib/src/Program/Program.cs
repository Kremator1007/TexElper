public class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates()
    {
        LogHandler.InitGlobalLog();
        FilesSelector = new FromJsonSelector(new JsonStringFromFileExtractor());
        BackendFileComparer = new BasicFileComparer(new ByLevenshteinProblemComparer());
        Printer = new DefaultPrinter(new System.IO.StreamWriter("out.txt"));
    }

    public ResultData? RunProgram()
    {
        var maybeInputData = FilesSelector.SelectFilesForFindingSimilarProblems();
        if (maybeInputData is ErrorWrapper<FilesToCompare, string> errorWrapper)
        {
            Printer.DisplayErrorMessage(errorWrapper.Error);
            return null;
        }
        else
        {
            var resultData = BackendFileComparer.CompareFiles(maybeInputData.Extract()!);
            Printer.Display(resultData);
            return resultData;
        }
    }

    public IFilesSelector FilesSelector { get; }
    private IBackendFileComparer BackendFileComparer { get; }
    private IPrettyPrinter Printer { get; }
}
