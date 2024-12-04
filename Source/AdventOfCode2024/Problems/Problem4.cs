namespace AdventOfCode2024.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/4">Day 4</a>.
/// </summary>
public class Problem4(InputDownloader inputDownloader) : ProblemBase(4, inputDownloader)
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
        var width = list.First().Length;
        var height = list.Count;

        var wordSearch = new Matrix<char>(width, height);

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                wordSearch[new Coordinate(x, y)] = list[y][x];
            }
        }

        var foundWords = 0;

        var charMap = new Dictionary<int, char>
        {
            [0] = 'X',
            [1] = 'M',
            [2] = 'A',
            [3] = 'S',
        };

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var coordinate = new Coordinate(x, y);
                if (!wordSearch[coordinate].Equals(charMap[0]))
                {
                    continue;
                }

                foreach (var direction in Vector.AllTwoDimensionalVectors)
                {
                    var isMatch = true;

                    for (var i = 1; i < charMap.Keys.Count; i++)
                    {
                        var neighbour = coordinate + direction * i;

                        if (neighbour.X < 0 || neighbour.X > width ||
                            neighbour.Y < 0 || neighbour.Y > height)
                        {
                            isMatch = false;
                            break;
                        }

                        if (wordSearch[neighbour] != charMap[i])
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                    {
                        foundWords++;
                    }
                }
            }
        }

        return foundWords;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var list = input.ToList();

        var width = list.First().Length;
        var height = list.Count;

        var wordSearch = new Matrix<char>(width, height);

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                wordSearch[new Coordinate(x, y)] = list[y][x];
            }
        }

        var foundMas = 0;

        for (var y = 1; y < height - 1; y++)
        {
            for (var x = 1; x < width - 1; x++)
            {
                var coordinate = new Coordinate(x, y);

                if (!wordSearch[coordinate].Equals('A'))
                {
                    continue;
                }

                if (wordSearch[coordinate + Vector.North + Vector.West].Equals('M') &&
                    wordSearch[coordinate + Vector.North + Vector.East].Equals('M') &&
                    wordSearch[coordinate + Vector.South + Vector.East].Equals('S') &&
                    wordSearch[coordinate + Vector.South + Vector.West].Equals('S'))
                {
                    foundMas++;
                }
                else if (wordSearch[coordinate + Vector.North + Vector.West].Equals('S') &&
                         wordSearch[coordinate + Vector.North + Vector.East].Equals('M') &&
                         wordSearch[coordinate + Vector.South + Vector.East].Equals('M') &&
                         wordSearch[coordinate + Vector.South + Vector.West].Equals('S'))
                {
                    foundMas++;
                }
                else if (wordSearch[coordinate + Vector.North + Vector.West].Equals('S') &&
                         wordSearch[coordinate + Vector.North + Vector.East].Equals('S') &&
                         wordSearch[coordinate + Vector.South + Vector.East].Equals('M') &&
                         wordSearch[coordinate + Vector.South + Vector.West].Equals('M'))
                {
                    foundMas++;
                }
                else if (wordSearch[coordinate + Vector.North + Vector.West].Equals('M') &&
                         wordSearch[coordinate + Vector.North + Vector.East].Equals('S') &&
                         wordSearch[coordinate + Vector.South + Vector.East].Equals('S') &&
                         wordSearch[coordinate + Vector.South + Vector.West].Equals('M'))
                {
                    foundMas++;
                }
            }
        }

        return foundMas;
    }
}