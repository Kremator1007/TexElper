using System.Collections.Generic;


record Problem(string text, System.IO.FileInfo fileOfTheProblem);


record FileWithProblems(List<Problem> problems);

record SimilarProblemsCase(Problem fst, Problem snd);


record ResultData(List<SimilarProblemsCase> similarProblemsCases);
