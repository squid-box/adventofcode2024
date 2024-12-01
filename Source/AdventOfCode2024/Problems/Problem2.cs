namespace AdventOfCode2024.Problems;

using System.Collections.Generic;

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
        return "Unsolved";
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return "Unsolved";
    }
}