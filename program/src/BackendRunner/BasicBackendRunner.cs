using System.Collections.Generic;
using System.Linq;
using UsefulExtensions;

class BasicBackendRunner : BackendRunner
{
    public override ResultData ProcessInput(InputData inputData)
    {
        var filesWithProblems = inputData.AllRelevantFiles.Select(
            fileInfo => new FileWithProblems(FileProcessor.ReadFile(fileInfo))
        );
        return pairwiseCompareFiles(filesWithProblems);
    }

    private ResultData pairwiseCompareFiles(IEnumerable<FileWithProblems> files)
    {
        var similarities = files
            .Pairwise()
            .SelectMany(pairOfFiles => CompareTwoFiles(pairOfFiles.Item1, pairOfFiles.Item2))
            .ToList();
        return new ResultData(SimilarProblemsCases: similarities);
    }

    private static List<SimilarProblemsCase> CompareTwoFiles(FileWithProblems fst, FileWithProblems snd) =>
        Tools.CartesianProduct(fst.Problems, snd.Problems)
             .Where(pairOfProblems => CompareTwoProblems(pairOfProblems.Item1, pairOfProblems.Item2))
             .Select(pairOfProblems => new SimilarProblemsCase(pairOfProblems.Item1, pairOfProblems.Item2))
             .ToList();

    private static bool CompareTwoProblems(Problem fst, Problem snd)
    {
        return Tools.LevenshteinDistance(fst.Text, snd.Text) < 42;
    }
}