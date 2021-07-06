using System;

class ProgramToFindDuplicates
{
    public ProgramToFindDuplicates() { }
    public void RunProgram()
    {
        var inputData = ioHandler.readInputForFindingSimilarProblems();
        var resultData = backendRunner.processInput(inputData);
        printer.Display(resultData);
    }
    private IOHandler ioHandler;
    private BackendRunner backendRunner;
    private PrettyPrinter printer;

}

class MainClass
{
    public static void Main()
    {
        var program = new ProgramToFindDuplicates();
        program.RunProgram();
    }
}

