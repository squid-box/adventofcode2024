namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2024.Utils;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/14">Day 14</a>.
/// </summary>
public class Problem14(InputDownloader inputDownloader) : ProblemBase(14, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input, 101, 103);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input, 101, 103);
    }

    public static object PartOne(IEnumerable<string> input, int width, int height)
    {
        var robots = new List<Robot>();

        foreach (var line in input)
        {
            robots.Add(new Robot(line));
        }

        // Move for 100 seconds.
        for (var n = 0; n < 100; n++)
        {
            foreach (var robot in robots)
            {
                robot.Move(width, height);
            }
        }

        // Count robots in each quadrant
        return robots.Count(r => r.Position.X > width / 2 && r.Position.Y > height / 2) *
               robots.Count(r => r.Position.X < width / 2 && r.Position.Y > height / 2) *
               robots.Count(r => r.Position.X > width / 2 && r.Position.Y < height / 2) *
               robots.Count(r => r.Position.X < width / 2 && r.Position.Y < height / 2);
    }

    public static object PartTwo(IEnumerable<string> input, int width, int height)
    {
        var robots = new List<Robot>();

        foreach (var line in input)
        {
            robots.Add(new Robot(line));
        }

        for (var n = 0; n < 1000; n++)
        {
            foreach (var robot in robots)
            {
                robot.Move(width, height);
            }

            var map = new Matrix<char>(width, height);

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (robots.Any(r => r.Position.Equals(new Coordinate(x, y))))
                    {
                        map[x, y] = '#';
                    }
                    else
                    {
                        map[x, y] = '.';
                    }
                }
            }

            Console.WriteLine($"Iteration {n}");
            Console.WriteLine(map);
            Console.ReadLine();
        }

        return "huh?";
    }

    private class Robot
    {
        private readonly Vector _velocity;

        public Robot(string input)
        {
            var match = Regex.Match(input, @"p=(?<position>\d+,\d+) v=(?<velocity>-?\d+,-?\d+)");
            var rawPos = match.Groups["position"].Value.Split(',');
            var rawVel = match.Groups["velocity"].Value.Split(",");

            Position = new Coordinate(rawPos[0].ToInt(), rawPos[1].ToInt());
            _velocity = new Vector(rawVel[0].ToInt(), rawVel[1].ToInt());
        }

        public Coordinate Position { get; private set; }

        public void Move(int maxWidth, int maxHeight)
        {
            var newPosition = Position + _velocity;
            Position = new Coordinate(PositiveModulo(newPosition.X, maxWidth), PositiveModulo(newPosition.Y, maxHeight));
        }

        private long PositiveModulo(long value, int mod)
        {
            return (value % mod + mod) % mod;
        }
    }
}