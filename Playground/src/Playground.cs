public static class Playground
{
    public static void Main()
    {
        const string path = @"C:\Users\James\Desktop\My documents\tmp";
        var filesSelector = new FilesByDirectoriesSelector(
            new ConstantDirectoriesSelector(new string[] { path })
        );
        var backendFileComparer = new BasicFileComparer(new ByLevenshteinProblemComparer());
        var printer = new DefaultPrinter(System.Console.Out);

        var inputData = filesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = backendFileComparer.CompareFiles(inputData);
        printer.Display(resultData);
    }
}