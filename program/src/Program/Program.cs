using System;

class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates() { }
    public void RunProgram()
    {
        var inputData = ioHandler.ReadInputForFindingSimilarProblems();
        var resultData = backendRunner.ProcessInput(inputData);
        printer.Display(resultData);
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
        program.RunProgram();
    }
}