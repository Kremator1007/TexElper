using System;
using System.Linq;

public class UserAskedDirectoriesSelector : IDirectoriesSelector
{
    public string[] SelectDirs()
    {
        string curDir = System.IO.Directory.GetCurrentDirectory();
        PrintEnterMessage(curDir);
        var paths = Tools.ReadConsoleLines()
            .Where(System.IO.Directory.Exists)
            .ToArray();
        PrintWarningOnTheNumberOfExistingDirs(paths.Length);
        return paths;
    }

    private static void PrintWarningOnTheNumberOfExistingDirs(int numOfExistingDirs)
    {
        Console.WriteLine($"{numOfExistingDirs} directories were successfully found");
    }

    private static void PrintEnterMessage(string curDir)
    {
        System.Console.WriteLine("Please enter the directories with files; otherwise " +
                                $"the current directory will be used ({curDir}).");
        System.Console.WriteLine("After	inputting all the directories, press enter:");
    }
}