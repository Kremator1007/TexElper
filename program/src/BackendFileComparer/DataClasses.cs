using System.Collections.Generic;


public record Problem(string Text, string PathToTheFileOfTheProblem);

public record FilesToCompare(List<string> AllRelevantFiles);

public record FileWithProblems(List<Problem> Problems);

public record SimilarProblemsCase(Problem Fst, Problem Snd);

public record ResultData(List<SimilarProblemsCase> SimilarProblemsCases);