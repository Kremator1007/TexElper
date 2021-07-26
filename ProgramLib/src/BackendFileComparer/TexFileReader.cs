using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class TexFileReader
{
    public static List<Problem> ReadFile(string pathToTheFile)
    {
        var problems = new List<Problem>();
        string[] lines = System.IO.File.ReadAllLines(pathToTheFile);
        string[] docLines = TrimRedundantTexParts(lines);
        for (int i = 0; i < docLines.Length; ++i)
        {
            var currentLine = docLines[i];
            if (currentLine.TrimStart(' ', '\t').StartsWith(@"\q"))
            {
                var problem = ReadProblemStartingFromLine(
                    docLines, i, pathToTheFile);
                problems.Add(problem);
            }
        }
        LogResultOfProblemReading(problems, pathToTheFile);
        return problems;
    }

    private static void LogResultOfProblemReading(List<Problem> problems, string pathToTheFile)
    {
        var strWriter = new System.IO.StringWriter();
        strWriter.Write("Problems read from \"{0}\":\n", pathToTheFile);
        foreach (var problem in problems)
        {
            strWriter.Write("\n---begin\n{0}\n---end\n", problem.Text);
        }
        Serilog.Log.Logger.Debug(strWriter.ToString());
    }

    private static Problem ReadProblemStartingFromLine(
        string[] lines,
        int startingLine,
        string pathToTheFileOfTheProblem)
    {
        var problemText = new StringBuilder();
        //second line clears preceding \q
        problemText.Append(lines[startingLine].TrimStart()[2..].TrimStart());
        var problemLines = lines
            .Skip(startingLine + 1)
            .TakeWhile(ContinuesTheProblem);
        foreach (string problemLine in problemLines)
            problemText.AppendLine(problemLine);
        string problemTextAsString = PreprocessProblemText(problemText);
        return new Problem(problemTextAsString, pathToTheFileOfTheProblem);
    }

    private static string PreprocessProblemText(StringBuilder problemText)
    {
        string problemTextString = problemText.ToString();
        problemTextString = Regex.Replace(problemTextString, "\n", "  ");
        problemTextString = Regex.Replace(problemTextString, " +", " ");
        problemTextString = problemTextString.Trim();
        return problemTextString;
    }

    private static bool ContinuesTheProblem(string s)
    {
        s = s.Trim();
        if (s.Length == 0)
            return true;
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
        var isDocumentStartRegex = new Regex
        (
            GetRegexString_IsDocumentSth("begin")
        );
        return isDocumentStartRegex.Match(str).Success;
    }

    private static bool IsDocumentEnd(string str)
    {
        var isDocumentEnd = new Regex
        (
            GetRegexString_IsDocumentSth("end")
        );
        return isDocumentEnd.Match(str).Success;
    }

    private static string GetRegexString_IsDocumentSth(string sth)
    {
        const string zeroOrMoreSpacesRegexString = " *";
        return
            sth +
            zeroOrMoreSpacesRegexString +
            "{" +
            zeroOrMoreSpacesRegexString +
            "document" +
            zeroOrMoreSpacesRegexString +
            "}";
    }
}