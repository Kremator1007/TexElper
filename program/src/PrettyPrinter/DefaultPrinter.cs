class DefaultPrinter : PrettyPrinter
{
    public override void Display(ResultData resultData)
    {
        System.Console.Write($"There are {resultData.SimilarProblemsCases.Count} cases of " +
                              "suspected problems repetition:\n\n\n");
        foreach (var similarProblemCase in resultData.SimilarProblemsCases)
        {
            System.Console.Write($"In files {similarProblemCase.Fst.FileOfTheProblem.Name} and " +
                                 $"{similarProblemCase.Snd.FileOfTheProblem.Name} with the text:\n");
            System.Console.Write("1: " + similarProblemCase.Fst.Text + "\n");
            System.Console.Write("2: " + similarProblemCase.Snd.Text + "\n");
            System.Console.Write("\n\n");
        }
        System.Console.WriteLine("Press any key to quit");
        System.Console.ReadKey();
    }
}