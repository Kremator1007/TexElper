class InputData
{
    readonly System.Collections.Generic.List<System.IO.FileInfo> allRelevantFiles;
    readonly System.Collections.Generic.List<System.IO.FileInfo> checkedFiles;
}

abstract class IOHandler
{
    public abstract InputData readInputForFindingSimilarProblems();
}