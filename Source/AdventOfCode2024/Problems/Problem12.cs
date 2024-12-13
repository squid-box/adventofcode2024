namespace AdventOfCode2024.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/12">Day 12</a>.
/// </summary>
public class Problem12(InputDownloader inputDownloader) : ProblemBase(12, inputDownloader)
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
        var list = input.ToList();
        var height = list.Count;
        var width = list.First().Length;

        var map = new Matrix<char>(width, height);

        for (var y = 0; y < height; y++)
        {
            var line = list[y];

            for (var x = 0; x < width; x++)
            {
                map[x, y] = line[x];
            }
        }

        return 0;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return "Unsolved";
    }
}