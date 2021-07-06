using System.Collections.Generic;
using System.Linq;
using UsefulExtensions;

class BasicBackendRunner : BackendRunner
{
    public override ResultData processInput(InputData inputData)
    {
        var filesWithProblems = inputData.allRelevantFiles.Select(
            fileInfo => new FileWithProblems(fileInfo)
        );
        return pairwiseCompareFiles(filesWithProblems);
    }

    private ResultData pairwiseCompareFiles(IEnumerable<FileWithProblems> files)
    {
        var filePairs = files.Pairwise();
        foreach (var (fst, snd) in filePairs)
        {

        }
    }
}