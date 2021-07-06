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
        var similarities = files.Pairwise()
                             .SelectMany(pairOfFiles => compareTwoFiles(pairOfFiles.Item1, pairOfFiles.Item2))
                             .ToList();
        return new ResultData(similarities);
    }

    private List<SimilarProblemsCase> compareTwoFiles(FileWithProblems fst, FileWithProblems snd) =>
        Tools.CartesianProduct(fst.problems, snd.problems)
             .Where(pairOfProblems => compareTwoProblems(pairOfProblems.Item1, pairOfProblems.Item2))
             .Select(pairOfProblems => new SimilarProblemsCase(pairOfProblems.Item1, pairOfProblems.Item2))
             .ToList();

    private bool compareTwoProblems(Problem fst, Problem snd)
    {
        return Tools.LevenshteinDistance(fst.text, snd.text) < 42;
    }
}