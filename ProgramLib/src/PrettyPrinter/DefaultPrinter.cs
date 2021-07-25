public class DefaultPrinter : IPrettyPrinter
{
    public DefaultPrinter(System.IO.TextWriter textWriter) =>
        OutputStream = textWriter;

    public void Display(ResultData resultData)
    {
        PrintEnterMessage(resultData);
        foreach (var similarProblemCase in resultData.SimilarProblemsCases)
        {
            PrintSimilarProblemCaseInfo(similarProblemCase);
        }
        OutputStream.Flush();
    }
    private System.IO.TextWriter OutputStream { get; }
    private void PrintEnterMessage(ResultData resultData)
    {
        int similarProblemCasesCount = resultData.SimilarProblemsCases.Count;
        string message = similarProblemCasesCount > 0
            ? $"There are {resultData.SimilarProblemsCases.Count} cases of " +
                              "suspected problems repetition:"
            : "There are no cases of possible problems repetitions";
        OutputStream.WriteLine(message);
    }

    private void PrintSimilarProblemCaseInfo(SimilarProblemsCase similarProblemCase)
    {
        OutputStream.Write("\n\n");
        OutputStream.Write($"In files {similarProblemCase.Fst.PathToTheFileOfTheProblem} and " +
                             $"{similarProblemCase.Snd.PathToTheFileOfTheProblem} with the text:\n");
        OutputStream.Write("1: " + similarProblemCase.Fst.Text + "\n");
        OutputStream.Write("2: " + similarProblemCase.Snd.Text + "\n");
    }
}