using System;

class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates()
    {
        ioHandler = new FilesInCurrentFolderSelector();
        backendRunner = new BasicBackendRunner(new ActualProblemComparer());
    }
    public ResultData RunProgram()
    {
        var inputData = ioHandler.ReadInputForFindingSimilarProblems();
        var resultData = backendRunner.ProcessInput(inputData);
        printer?.Display(resultData);
        return resultData;
    }
    private readonly IOHandler ioHandler;
    private readonly BackendRunner backendRunner;
    private readonly PrettyPrinter printer;
}

class MainClass
{
    public static void Main()
    {
        var program = new ProgramToFindDuplicates();
        _ = program.RunProgram();
    }
}