using System;

public class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates()
    {
        filesSelector = new FilesInUserAskedFolderSelector();
        backendFileComparer = new BasicFileComparer(new ByLevenshteinProblemComparer());
        printer = new DefaultPrinter();
    }
    public ResultData RunProgram()
    {
        var inputData = filesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = backendFileComparer.CompareFiles(inputData);
        printer.Display(resultData);
        return resultData;
    }
    private readonly FilesSelector filesSelector;
    private readonly IBackendFileComparer backendFileComparer;
    private readonly IPrettyPrinter printer;
}
