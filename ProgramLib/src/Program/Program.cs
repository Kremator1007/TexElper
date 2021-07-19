using System;

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
        var inputData = filesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = backendFileComparer.CompareFiles(inputData);
        printer.Display(resultData);
        return resultData;
    }
    private readonly IFilesSelector filesSelector;
    private readonly IBackendFileComparer backendFileComparer;
    private readonly IPrettyPrinter printer;
}
