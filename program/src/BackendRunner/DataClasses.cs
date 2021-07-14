using System.Collections.Generic;


public record Problem(string Text, System.IO.FileInfo FileOfTheProblem);

record InputData(List<System.IO.FileInfo> AllRelevantFiles,
    List<System.IO.FileInfo> CheckedFiles);

record FileWithProblems(List<Problem> Problems);

record SimilarProblemsCase(Problem Fst, Problem Snd);

record ResultData(List<SimilarProblemsCase> SimilarProblemsCases);