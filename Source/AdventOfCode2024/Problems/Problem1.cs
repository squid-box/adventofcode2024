namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/1">Day 1</a>.
/// </summary>
public class Problem1(InputDownloader inputDownloader) : ProblemBase(1, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input);
    }

    public static int PartOne(IEnumerable<string> input)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var line in input)
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            leftList.Add(split[0].ToInt());
            rightList.Add(split[1].ToInt());
        }

        leftList.Sort();
        rightList.Sort();

        var sumOfDifferences = 0;

        for (var i = 0; i < leftList.Count; i++)
        {
            sumOfDifferences += Math.Abs(leftList[i] - rightList[i]);
        }

        return sumOfDifferences;
    }

    public static long PartTwo(IEnumerable<string> input)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var line in input)
        {
            var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            leftList.Add(split[0].ToInt());
            rightList.Add(split[1].ToInt());
        }

        var sumOfSimilarityScores = 0;

        foreach (var leftNumber in leftList)
        {
            var rightListCount = rightList.Count(n => n == leftNumber);

            sumOfSimilarityScores += rightListCount * leftNumber;
        }

        return sumOfSimilarityScores;
    }
}