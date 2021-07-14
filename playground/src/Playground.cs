using System;

public class Playground
{
    public static void Main()
    {
        string path = "media\\b.tex";
        var file = new System.IO.FileInfo(path);
        var t = FileProcessor.ReadFile(file);
        foreach (Problem problem in t)
        {
            Console.WriteLine();
            Console.WriteLine(problem.Text);
        }
    }
}