namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/15">Day 15</a>.
/// </summary>
public class Problem15(InputDownloader inputDownloader) : ProblemBase(15, inputDownloader)
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
        var inputChunks = input.ToList().SplitByBlankLines();

        var warehouse = new Warehouse(inputChunks[0]);
        var instructions = string.Join("", inputChunks[1]);

        foreach (var c in instructions)
        {
            warehouse.MoveRobot(c);
        }

        return warehouse.Map.GetElements()
            .Where(tuple => tuple.Element == 'O')
            .Select(tuple => tuple.Position)
            .Sum(CalculateGpsCoordinate);
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var inputChunks = input.ToList().SplitByBlankLines();

        var warehouse = new Warehouse(inputChunks[0], wide: true);
        var instructions = string.Join("", inputChunks[1]);

        foreach (var c in instructions)
        {
            warehouse.MoveWideRobot(c);
        }

        warehouse.Map[warehouse.Robot] = '@';
        Console.WriteLine(warehouse.Map);

        return warehouse.Map.GetElements()
            .Where(tuple => tuple.Element == '[')
            .Select(tuple => tuple.Position)
            .Sum(CalculateGpsCoordinate);
    }

    private class Warehouse
    {
        public Warehouse(IList<string> input, bool wide = false)
        {
            var height = input.Count;
            var width = input.First().Length;

            Map = new Matrix<char>(width * (wide ? 2 : 1) + (wide ? 1 : 0), height);

            for (var y = 0; y < height; y++)
            {
                var line = input[y];

                var newLine = "";

                foreach (var c in line)
                {
                    if (c == '#')
                    {
                        newLine += "##";
                    }
                    else if (c == '@')
                    {
                        newLine += "@.";
                    }
                    else if (c == '.')
                    {
                        newLine += "..";
                    }
                    else if (c == 'O')
                    {
                        newLine += "[]";
                    }
                }

                line = newLine;

                for (var x = 0; x < line.Length; x++)
                {
                    var current = line[x];

                    if (current == '@')
                    {
                        Robot = new Coordinate(x, y);
                        Map[x, y] = '.';
                    }
                    else
                    {
                        Map[x, y] = current;
                    }
                }
            }
        }

        public Matrix<char> Map { get; }

        public Coordinate Robot { get; private set; }

        public void MoveRobot(char instruction)
        {
            // Determine where we're going...
            var direction = instruction switch
            {
                '<' => Vector.West,
                '>' => Vector.East,
                'v' => Vector.South,
                '^' => Vector.North,
                _ => throw new Exception($"Unexpected instruction: '{instruction}'.")
            };

            var nextPosition = Robot + direction;
            var boxesToMove = new List<Coordinate>();
            var foundWall = false;

            // Check what's in that direction...
            while (Map.IsWithinBounds(nextPosition))
            {
                var nextTile = Map[nextPosition];

                if (nextTile == '.')
                {
                    // We're at an empty space!
                    break;
                }

                if (nextTile == '#')
                {
                    foundWall = true;
                    break;
                }

                if (nextTile == 'O')
                {
                    boxesToMove.Add(nextPosition);
                }

                nextPosition += direction;
            }

            if (!foundWall)
            {
                boxesToMove.Reverse();

                foreach (var box in boxesToMove)
                {
                    Map[box] = '.';
                    Map[box + direction] = 'O';
                }

                Robot += direction;
            }
        }

        public void MoveWideRobot(char instruction)
        {
            // Determine where we're going...
            var direction = instruction switch
            {
                '<' => Vector.West,
                '>' => Vector.East,
                'v' => Vector.South,
                '^' => Vector.North,
                _ => throw new Exception($"Unexpected instruction: '{instruction}'.")
            };

            var nextPosition = Robot + direction;
            var boxesToMove = new List<Coordinate>();
            var foundWall = false;

            // Check what's in that direction...
            while (Map.IsWithinBounds(nextPosition))
            {
                var nextTile = Map[nextPosition];

                if (nextTile == '.')
                {
                    // We're at an empty space!
                    break;
                }

                if (nextTile == '#')
                {
                    foundWall = true;
                    break;
                }

                if (nextTile == '[')
                {
                    boxesToMove.Add(nextPosition);
                    boxesToMove.Add(nextPosition + Vector.East);
                }
                else if (nextTile == ']')
                {
                    boxesToMove.Add(nextPosition);
                    boxesToMove.Add(nextPosition + Vector.West);
                }

                // TODO: if we're moving on the Y-axis, we need to do a lot more collision/pushing checks...

                nextPosition += direction;
            }

            if (!foundWall)
            {
                boxesToMove.Reverse();

                var boxesMoved = new HashSet<Coordinate>();

                foreach (var box in boxesToMove)
                {
                    if (boxesMoved.Contains(box))
                    {
                        continue;
                    }

                    if (Map[box] == '[')
                    {
                        Map[box] = '.';
                        Map[box + Vector.East] = '.';

                        Map[box + direction] = '[';
                        Map[box + Vector.East + direction] = ']';

                        boxesMoved.Add(box);
                        boxesMoved.Add(box + Vector.East);
                    }
                    else
                    {
                        Map[box] = '.';
                        Map[box + Vector.West] = '.';

                        Map[box + direction] = ']';
                        Map[box + Vector.West + direction] = '[';

                        boxesMoved.Add(box);
                        boxesMoved.Add(box + Vector.West);
                    }
                }

                Robot += direction;
            }
        }
    }

    private static long CalculateGpsCoordinate(Coordinate box)
    {
        return (box.Y * 100) + box.X;
    }
}