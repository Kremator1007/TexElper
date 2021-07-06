using System.Collections.Generic;
class InputData
{
    public readonly List<System.IO.FileInfo> allRelevantFiles;
    public readonly List<System.IO.FileInfo> checkedFiles;
}

abstract class IOHandler
{
    public abstract InputData readInputForFindingSimilarProblems();
}