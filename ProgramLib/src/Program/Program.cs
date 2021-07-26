using System;

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
            LogSelectedFiles(maybeInputData.Extract()!);
            var resultData = BackendFileComparer.CompareFiles(maybeInputData.Extract()!);
            Printer.Display(resultData);
            return resultData;
        }
    }

    private void LogSelectedFiles(FilesToCompare filesToCompare)
    {
        var strWriter = new System.IO.StringWriter();
        strWriter.Write("The following files were selected and pairwise compared:\n");
        foreach (string filePath in filesToCompare.AllRelevantFiles)
            strWriter.Write("\t{0}\n", filePath);
        Serilog.Log.Logger.Debug(strWriter.ToString());
    }

    public IFilesSelector FilesSelector { get; }
    private IBackendFileComparer BackendFileComparer { get; }
    private IPrettyPrinter Printer { get; }
}
