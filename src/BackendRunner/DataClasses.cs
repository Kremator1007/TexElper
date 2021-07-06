using System.Collections.Generic;

class Problem
{
    public readonly string text;
    public readonly System.IO.FileInfo fileOfTheProblem;
}

class FileWithProblems
{
    public FileWithProblems(System.IO.FileInfo file) { }
    public List<Problem> problems;
}

class SimilarProblemsCase
{
    public SimilarProblemsCase(Problem fst, Problem snd) =>
        (this.fst, this.snd) = (fst, snd);

    public readonly Problem fst, snd;
}

class ResultData
{
    public ResultData(List<SimilarProblemsCase> similarProblemsCases) =>
        this.similarProblemsCases = similarProblemsCases;

    public readonly List<SimilarProblemsCase> similarProblemsCases;
}

