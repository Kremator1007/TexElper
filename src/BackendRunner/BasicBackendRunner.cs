using System.Collections.Generic;
class BasicBackendRunner : BackendRunner
{
    public override ResultData processInput(InputData inputData)
    {
        return new ResultData();
    }
}

class Problem
{
    private string text;
}

class FileWithProblems
{
    public FileWithProblems(System.IO.FileInfo file) { }
    private List<Problem> problems;
}