using System;

public class Playground
{
    public static void Main()
    {
        var path = @"C:\Users\James\Desktop\My documents\tmp";
        var filesSelector = new FilesInUserAskedFolderSelector(path);
        var backendFileComparer = new BasicFileComparer(new ByLevenshteinProblemComparer());
        var printer = new DefaultPrinter();

        var inputData = filesSelector.SelectFilesForFindingSimilarProblems();
        var resultData = backendFileComparer.CompareFiles(inputData);
        printer.Display(resultData);
    }
}