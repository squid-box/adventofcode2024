﻿namespace AdventOfCode2024.Generator;

using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.Error.WriteLine("You need to provide the root path.");
            Environment.Exit(1);
        }

        var rootPath = args[0];

        var originalWorkingDir = Environment.CurrentDirectory;
        Environment.CurrentDirectory = rootPath;

        CreateDailyProblemCodeFiles(DateTime.Today.Year);

        Environment.CurrentDirectory = originalWorkingDir;
        Console.Out.WriteLine("Done, exiting.");
    }

    private static void CreateDailyProblemCodeFiles(int year)
    {
        Console.Out.WriteLine("Create daily problem code files.");

        try
        {
            for (var day = 1; day < 26; day++)
            {
                var pathToProblemFile = Path.Combine("Source", $"AdventOfCode{year}", "Problems", $"Problem{day}.cs");
                var pathToProblemTestFile = Path.Combine("Source", $"AdventOfCode{year}.Tests", "Problems", $"Problem{day}Tests.cs");

                Directory.CreateDirectory(Path.GetDirectoryName(pathToProblemFile));
                File.WriteAllText(Path.Combine(pathToProblemFile), string.Format("namespace AdventOfCode{2}.Problems;{0}{0}using System.Collections.Generic;{0}{0}/// <summary>{0}/// Solution for <a href=\"https://adventofcode.com/{2}/day/{1}\">Day {1}</a>.{0}/// </summary>{0}public class Problem{1}(InputDownloader inputDownloader) : ProblemBase({1}, inputDownloader){0}{{{0}    /// <inheritdoc />{0}    protected override object SolvePartOne(){0}    {{{0}        return PartOne(Input);{0}    }}{0}{0}    /// <inheritdoc />{0}    protected override object SolvePartTwo(){0}    {{{0}        return PartTwo(Input);{0}    }}{0}{0}    public static object PartOne(IEnumerable<string> input){0}    {{{0}        return \"Unsolved\";{0}    }}{0}{0}    public static object PartTwo(IEnumerable<string> input){0}    {{{0}        return \"Unsolved\";{0}    }}{0}}}", Environment.NewLine, day, year));

                Directory.CreateDirectory(Path.GetDirectoryName(pathToProblemTestFile));
                File.WriteAllText(pathToProblemTestFile, string.Format("namespace AdventOfCode{2}.Tests.Problems;{0}{0}using AdventOfCode{2}.Problems;{0}using NUnit.Framework;{0}{0}[TestFixture]{0}public class Problem{1}Tests{0}{{{0}    private static readonly string[] TestInput ={0}    [{0}        {0}    ];{0}{0}    [Test]{0}    public void TestPartOne(){0}    {{{0}        Assert.That(Problem{1}.PartOne(TestInput), Is.EqualTo(4711));{0}    }}{0}{0}    [Test]{0}    public void TestPartTwo(){0}    {{{0}        Assert.That(Problem{1}.PartTwo(TestInput), Is.EqualTo(4711));{0}    }}{0}}}", Environment.NewLine, day, year));
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Problem generating files. {e.GetType()}: {e.Message}");
        }
    }
}