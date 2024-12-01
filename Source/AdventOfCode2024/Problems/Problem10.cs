namespace AdventOfCode2024.Problems;

using System.Collections.Generic;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/10">Day 10</a>.
/// </summary>
public class Problem10(InputDownloader inputDownloader) : ProblemBase(10, inputDownloader)
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