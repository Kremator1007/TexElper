using System.Collections.Generic;
class InputData
{
    readonly List<System.IO.FileInfo> allRelevantFiles;
    readonly List<System.IO.FileInfo> checkedFiles;
}

abstract class IOHandler
{
    public abstract InputData readInputForFindingSimilarProblems();
}