using System.Linq;
class FilesInCurrentFolderSelector : IOHandler
{
    public FilesInCurrentFolderSelector() =>
        SearchPath = AskUserForTheDirectory();
    public override InputData ReadInputForFindingSimilarProblems()
    {
        var files = System.IO.Directory.EnumerateFiles(SearchPath)
                .Select((string fileName) => fileName.EndsWith(".tex"))
                .Cast<System.IO.FileInfo>()
                .ToList();
        return new InputData(files, files);
    }
    private static string AskUserForTheDirectory()
    {
        string curDir = System.IO.Directory.GetCurrentDirectory();
        System.Console.WriteLine("Please enter the directory with files; otherwise " +
                                $"the current directory will be used ({curDir})");
        string? input = System.Console.ReadLine();
        if (input == "") return curDir;
        else return input ?? curDir;
    }
    private readonly string SearchPath;
}