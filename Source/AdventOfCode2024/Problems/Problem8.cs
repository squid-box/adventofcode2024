namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/8">Day 8</a>.
/// </summary>
public class Problem8(InputDownloader inputDownloader) : ProblemBase(8, inputDownloader)
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

    private static Dictionary<char, List<Coordinate>> FindAntennas(IList<string> input)
    {
        var antennas = new Dictionary<char, List<Coordinate>>();

        for (var y = 0; y < input.Count; y++)
        {
            var line = input[y];

            for (var x = 0; x < input.First().Length; x++)
            {
                var currentChar = line[x];

                if (currentChar.Equals('.'))
                {
                    continue;
                }

                if (!antennas.ContainsKey(currentChar))
                {
                    antennas.Add(currentChar, []);
                }

                antennas[currentChar].Add(new Coordinate(x, y));
            }
        }

        return antennas;
    }

    public static object PartOne(IEnumerable<string> input)
    {
        var inputList = input.ToList();

        var width = inputList.First().Length;
        var height = inputList.Count;
        var antennas = FindAntennas(inputList);
        var antiNodes = new HashSet<Coordinate>();

        // For each coordinate, see if any antenna pair creates an anti-node there.
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var currentCoordinate = new Coordinate(x, y);

                if (antiNodes.Contains(currentCoordinate))
                {
                    break;
                }

                foreach (var frequency in antennas.Keys)
                {
                    if (antiNodes.Contains(currentCoordinate))
                    {
                        break;
                    }

                    // Check all pairs of antennas of the current frequency for anti-nodes.
                    foreach (var pair in antennas[frequency].SelectMany((_, i) => antennas[frequency].Skip(i + 1), Tuple.Create))
                    {
                        // Point needs to be on a straight line that intersects both antennas.
                        if (!IsPointOnLine(currentCoordinate, pair.Item1, pair.Item2))
                        {
                            continue;
                        }

                        var distanceToFirstAntenna = (currentCoordinate - pair.Item1).Magnitude;
                        var distanceToSecondAntenna = (currentCoordinate - pair.Item2).Magnitude;

                        // Point needs to be double the distance to one of the antennas than the other.
                        if (Math.Abs(distanceToSecondAntenna - distanceToFirstAntenna * 2) > 0.01 &&
                            Math.Abs(distanceToFirstAntenna - distanceToSecondAntenna * 2) > 0.01)
                        {
                            continue;
                        }

                        antiNodes.Add(currentCoordinate);
                        break;
                    }
                }
            }
        }

        return antiNodes.Count;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var inputList = input.ToList();

        var antennas = FindAntennas(inputList);
        var width = inputList.First().Length;
        var height = inputList.Count;
        var antiNodes = new HashSet<Coordinate>();

        // For each coordinate, see if any antenna pair creates an anti-node there.
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var currentCoordinate = new Coordinate(x, y);

                if (antiNodes.Contains(currentCoordinate))
                {
                    break;
                }

                foreach (var frequency in antennas.Keys)
                {
                    if (antiNodes.Contains(currentCoordinate))
                    {
                        break;
                    }

                    // Check all pairs of antennas of the current frequency for anti-nodes.
                    foreach (var pair in antennas[frequency].SelectMany((_, i) => antennas[frequency].Skip(i + 1), Tuple.Create))
                    {
                        // Point needs to be on a straight line that intersects both antennas.
                        if (!IsPointOnLine(currentCoordinate, pair.Item1, pair.Item2))
                        {
                            continue;
                        }

                        antiNodes.Add(currentCoordinate);
                        break;
                    }
                }
            }
        }

        return antiNodes.Count;
    }

    // Cross product magic
    private static bool IsPointOnLine(Coordinate currentPoint, Coordinate pointA, Coordinate pointB)
    {
        var dxc = currentPoint.X - pointA.X;
        var dyc = currentPoint.Y - pointA.Y;

        var dxl = pointB.X - pointA.X;
        var dyl = pointB.Y - pointA.Y;

        return dxc * dyl == dyc * dxl;
    }
}