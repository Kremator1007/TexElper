using System.Collections.Generic;
using System.Linq;
using UsefulExtensions;

public class BasicBackendRunner : IBackendRunner
{
    public BasicBackendRunner(IProblemComparer comparer)
        => problemComparer = comparer;

    public ResultData ProcessInput(InputData inputData)
    {
        var filesWithProblems = inputData.AllRelevantFiles.Select(
            fileInfo => new FileWithProblems(FileProcessor.ReadFile(fileInfo))
        );
        return PairwiseCompareFiles(filesWithProblems);
    }

    private ResultData PairwiseCompareFiles(IEnumerable<FileWithProblems> files)
    {
        var similarities = files
            .Pairwise()
            .SelectMany(pairOfFiles => CompareTwoFiles(pairOfFiles.Item1, pairOfFiles.Item2))
            .ToList();
        return new ResultData(SimilarProblemsCases: similarities);
    }

    private List<SimilarProblemsCase> CompareTwoFiles(FileWithProblems fst, FileWithProblems snd) =>
        Tools.CartesianProduct(fst.Problems, snd.Problems)
             .Where(pairOfProblems => AreTwoProblemsSimilar(pairOfProblems.Item1, pairOfProblems.Item2))
             .Select(pairOfProblems => new SimilarProblemsCase(pairOfProblems.Item1, pairOfProblems.Item2))
             .ToList();

    private bool AreTwoProblemsSimilar(Problem fst, Problem snd)
    {
        return problemComparer.AreTwoProblemsSimilar(fst, snd);
    }
    private readonly IProblemComparer problemComparer;
}