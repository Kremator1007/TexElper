using System.Collections.Generic;

class Problem
{
    private string text;
    private System.IO.FileInfo fileOfTheProblem;
}

class FileWithProblems
{
    public FileWithProblems(System.IO.FileInfo file) { }
    private List<Problem> problems;
}

class SimilarProblemsCase
{
    Problem fst, snd;
}

class ResultData
{
    public readonly List<SimilarProblemsCase> similarProblemCases;
}

