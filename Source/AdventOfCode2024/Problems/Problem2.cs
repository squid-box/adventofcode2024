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

    private static bool IsLineSafe(IList<int> numbers)
    {
        var isIncreasing = numbers[1] - numbers[0] > 0;

        for (var i = 0; i < numbers.Count - 1; i++)
        {
            var diff = numbers[i + 1] - numbers[i];

            if (!Math.Abs(diff).IsWithin(1, 3) ||
                isIncreasing && diff < 0 ||
                !isIncreasing && diff > 0)
            {
                return false;
            }
        }

        return true;
    }

    public static object PartOne(IEnumerable<string> input)
    {
        var safeLines = 0;

        foreach (var line in input)
        {
            var numbers = line.Split(' ').AsInt();
            
            if (IsLineSafe(numbers))
            {
                safeLines++;
            }
        }

        return safeLines;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var numberOfSafeLines = 0;

        foreach (var line in input)
        {
            var numbers = line.Split(' ').AsInt();

            // Base check.
            if (IsLineSafe(numbers))
            {
                numberOfSafeLines++;
                continue;
            }

            // Problem Dampener check.
            for (var i = 0; i < numbers.Count; i++)
            {
                var numberCopy = numbers.ToList();
                numberCopy.RemoveAt(i);

                if (IsLineSafe(numberCopy))
                {
                    numberOfSafeLines++;
                    break;
                }
            }
        }

        return numberOfSafeLines;
    }
}