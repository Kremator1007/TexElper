using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class FileProcessor
{
    public static List<Problem> ReadFile(System.IO.FileInfo fileInfo)
    {
        var problems = new List<Problem>();
        string[] lines = System.IO.File.ReadAllLines(fileInfo.FullName);
        string[] docLines = TrimRedundantTexParts(lines);
        for (int i = 0; i < docLines.Length;)
        {
            var currentLine = docLines[i];
            if (currentLine.TrimStart(' ', '\t').StartsWith(@"\q"))
            {
                var (problem, lineCount) = ReadProblemStartingFromLine(docLines, i, fileInfo);
                problems.Add(problem);
                i += lineCount;
            }
            else
            {
                ++i;
            }
        }
        return problems;
    }

    private static (Problem, int) ReadProblemStartingFromLine(
        string[] lines,
        int startingLine,
        System.IO.FileInfo fileInfo)
    {
        var problemText = new StringBuilder();
        var lineCount = 1;
        //second line clears preceding \q
        problemText.Append(lines[startingLine].TrimStart()[2..].TrimStart());
        _ = lines
            .Skip(startingLine)
            .TakeWhile(ContinuesTheProblem)
            .Select((string line) =>
            {
                problemText.AppendLine(line);
                ++lineCount;
                return line;
            });
        return (new Problem(problemText.ToString(), fileInfo), lineCount);
    }

    private static bool ContinuesTheProblem(string s)
    {
        s = s.Trim();
        if (s == "")
            return false;
        else if (s.StartsWith(@"\q") || s.StartsWith(@"\end"))
            return false;
        else if (s.StartsWith("%"))
            return false;
        else
            return true;
    }

    private static string[] TrimRedundantTexParts(string[] fileLines)
    {
        return fileLines
            .SkipWhile(line => !IsDocumentStart(line))
            .Skip(1)
            .TakeWhile(line => !IsDocumentEnd(line))
            .ToArray();
    }

    private static bool IsDocumentStart(string str)
    {
        var zeroOrMoreSpacesRegexString = " *";
        var isDocumentStartRegex = new Regex
        (
            @"begin" +
            zeroOrMoreSpacesRegexString +
            "{" +
            zeroOrMoreSpacesRegexString +
            "document" +
            zeroOrMoreSpacesRegexString +
            "}"
        );
        if (isDocumentStartRegex.Match(str).Success)
            return true;
        else
            return false;
    }

    private static bool IsDocumentEnd(string str)
    {
        var zeroOrMoreSpacesRegexString = " *";
        var isDocumentEnd = new Regex
        (
            @"end" +
            zeroOrMoreSpacesRegexString +
            "{" +
            zeroOrMoreSpacesRegexString +
            "document" +
            zeroOrMoreSpacesRegexString +
            "}"
        );
        return isDocumentEnd.Match(str).Success;
    }
}