using System;

public class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates()
    {
        ioHandler = new FilesInCurrentFolderSelector();
        backendRunner = new BasicBackendRunner(new ActualProblemComparer());
        printer = new DefaultPrinter();
    }
    public ResultData RunProgram()
    {
        var inputData = ioHandler.ReadInputForFindingSimilarProblems();
        var resultData = backendRunner.ProcessInput(inputData);
        printer.Display(resultData);
        return resultData;
    }
    private readonly IOHandler ioHandler;
    private readonly IBackendRunner backendRunner;
    private readonly IPrettyPrinter printer;
}

class MainClass
{
    public static void Main()
    {
        var program = new ProgramToFindDuplicates();
        _ = program.RunProgram();
    }
}