namespace AdventOfCode2024.Problems;

using System.Collections.Generic;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/24">Day 24</a>.
/// </summary>
public class Problem24(InputDownloader inputDownloader) : ProblemBase(24, inputDownloader)
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