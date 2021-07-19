public class DefaultPrinter : IPrettyPrinter
{
    public void Display(ResultData resultData)
    {
        PrintEnterMessage(resultData);
        foreach (var similarProblemCase in resultData.SimilarProblemsCases)
        {
            PrintSimilarProblemCaseInfo(similarProblemCase);
        }
        PrintOuttroMessage();
    }

    private static void PrintEnterMessage(ResultData resultData)
    {
        int similarProblemCasesCount = resultData.SimilarProblemsCases.Count;
        string message = similarProblemCasesCount > 0
            ? $"There are {resultData.SimilarProblemsCases.Count} cases of " +
                              "suspected problems repetition:"
            : "There are no cases of possible problems repetitions";
        System.Console.WriteLine(message);
    }

    private static void PrintSimilarProblemCaseInfo(SimilarProblemsCase similarProblemCase)
    {
        System.Console.Write("\n\n");
        System.Console.Write($"In files {similarProblemCase.Fst.PathToTheFileOfTheProblem} and " +
                             $"{similarProblemCase.Snd.PathToTheFileOfTheProblem} with the text:\n");
        System.Console.Write("1: " + similarProblemCase.Fst.Text + "\n");
        System.Console.Write("2: " + similarProblemCase.Snd.Text + "\n");
    }


    private static void PrintOuttroMessage()
    {
        System.Console.WriteLine("Press any key to quit");
        System.Console.ReadKey();
    }
}