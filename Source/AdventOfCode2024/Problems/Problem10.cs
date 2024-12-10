namespace AdventOfCode2024.Problems;

using AdventOfCode2024.Utils;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;

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
        var map = ParseMap(input);
        var scores = 0;

        for (var y = 0; y < map.Height; y++)
        {
            for (var x = 0; x < map.Width; x++)
            {
                var current = new Coordinate(y, x);
                
                if (map[current] != 0)
                {
                    continue;
                }

                scores += TraverseTrailHeads(current, map).Heads.Count;
            }
        }

        return scores;
    }
    
    public static object PartTwo(IEnumerable<string> input)
    {
        var map = ParseMap(input);
        var rating = 0;

        for (var y = 0; y < map.Height; y++)
        {
            for (var x = 0; x < map.Width; x++)
            {
                var current = new Coordinate(y, x);

                if (map[current] != 0)
                {
                    continue;
                }

                rating += TraverseTrailHeads(current, map).Trails;
            }
        }

        return rating;
    }

    private static Matrix<int> ParseMap(IEnumerable<string> input)
    {
        var map = new Matrix<int>();

        var inputList = input.ToList();

        for (var y = 0; y < inputList.Count; y++)
        {
            var line = inputList[y];

            for (var x = 0; x < inputList.First().Length; x++)
            {
                map[x, y] = line[x].ToString().ToInt();
            }
        }

        return map;
    }

    private static (HashSet<Coordinate> Heads, int Trails) TraverseTrailHeads(Coordinate current, Matrix<int> map)
    {
        var trailHeads = new HashSet<Coordinate>();
        var rating = 0;

        foreach (var direction in Vector.CardinalVectors)
        {
            var next = current + direction;

            if (!map.IsWithinBounds(next) ||
                map[next] - map[current] != 1)
            {
                continue;
            }

            if (map[next] == 9)
            {
                trailHeads.Add(next);
                rating++;

                continue;
            }

            var (subTrailHeads, trails) = TraverseTrailHeads(next, map);

            foreach (var subhead in subTrailHeads)
            {
                trailHeads.Add(subhead);
            }
            
            rating += trails;
        }

        return (trailHeads, rating);
    }
}