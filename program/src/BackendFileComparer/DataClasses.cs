using System.Collections.Generic;


public record Problem(string Text, System.IO.FileInfo FileOfTheProblem);

public record FilesToCompare(List<System.IO.FileInfo> AllRelevantFiles);

public record FileWithProblems(List<Problem> Problems);

public record SimilarProblemsCase(Problem Fst, Problem Snd);

public record ResultData(List<SimilarProblemsCase> SimilarProblemsCases);