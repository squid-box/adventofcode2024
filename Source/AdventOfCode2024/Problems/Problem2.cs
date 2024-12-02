namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/2">Day 2</a>.
/// </summary>
public class Problem2(InputDownloader inputDownloader) : ProblemBase(2, inputDownloader)
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

    public static object PartOne(IEnumerable<string> input)
    {
        var numberOfSafeLines = 0;

        foreach (var line in input)
        {
            var isSafe = true;

            var numbers = line.Split(' ').AsInt();

            var isIncreasing = numbers[0] - numbers[1] > 0;

            for (var i = 0; i < numbers.Count - 1; i++)
            {
                var diff = numbers[i] - numbers[i + 1];

                if (isIncreasing && diff <= 0 ||
                    !isIncreasing && diff >= 0 ||
                    Math.Abs(diff) > 3)
                {
                    isSafe = false;
                }
            }

            if (isSafe)
            {
                numberOfSafeLines++;
            }
        }

        return numberOfSafeLines;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var numberOfSafeLines = 0;

        foreach (var line in input)
        {
            var isSafe = true;
            var numberOfErrors = 0;

            var numbers = line.Split(' ').AsInt();

            var isIncreasing = numbers[0] - numbers[1] > 0;

            for (var i = 0; i < numbers.Count - 1; i++)
            {
                var diff = numbers[i] - numbers[i + 1];

                if (Math.Abs(diff) > 3)
                {
                    if (numberOfErrors == 0)
                    {
                        numberOfErrors++;
                        continue;
                    }

                    isSafe = false;
                }
                else if (isIncreasing && diff <= 0 ||
                    !isIncreasing && diff >= 0)
                {
                    isSafe = false;
                }
                
            }

            if (isSafe)
            {
                numberOfSafeLines++;
            }
        }

        return numberOfSafeLines;
    }
}