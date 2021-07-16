using System.Linq;
class FilesInCurrentFolderSelector : IOHandler
{
    public override InputData ReadInputForFindingSimilarProblems()
    {
        string SearchPath = AskUserForTheDirectory();
        var files = System.IO.Directory.EnumerateFiles(SearchPath)
                .Where((string fileName) => fileName.EndsWith(".tex"))
                .Select((string path) => new System.IO.FileInfo(path))
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
}