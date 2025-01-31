﻿using System;
using System.Collections.Generic;

public static class ProblemInFileShower
{
    public static void Run()
    {
        PrintEntryMessage();
        string? pathToFile = SelectFile();
        if (pathToFile is not null)
        {
            List<Problem> fileWithProblems = TexFileReader.ReadFile(pathToFile);
            PrintProblems(fileWithProblems);
        }
        PrintOuttroMessage();
    }

    private static void PrintEntryMessage()
    {
        Console.WriteLine("Hello there! Choose a file - this program will print " +
        "the problems from the file the way it sees it:");
    }

    //returns null if readLine doesnt result in a correct file path
    private static string? SelectFile()
    {
        string? inputFilePath = Console.ReadLine();
        if (inputFilePath is null)
        {
            Console.WriteLine("Weird, we got a null... Try again?");
            return null;
        }
        else if (!System.IO.File.Exists(inputFilePath))
        {
            Console.WriteLine("Weird, we got an invalid path... Try again?");
            return null;
        }
        else
        {
            return inputFilePath;
        }
    }

    private static void PrintProblems(List<Problem> fileWithProblems)
    {
        foreach (var problem in fileWithProblems)
        {
            Console.WriteLine("------------begin--------------");
            Console.WriteLine(problem.Text);
            Console.WriteLine("------------end----------------\n");
        }
    }

    private static void PrintOuttroMessage()
    {
        Console.WriteLine("Press any key to continue");
        _ = Console.ReadKey();
    }
}

