namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2024.Utils;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/13">Day 13</a>.
/// </summary>
public class Problem13(InputDownloader inputDownloader) : ProblemBase(13, inputDownloader)
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
        var inputGroups = input.ToList().SplitByBlankLines();

        var sumForPrizes = 0L;

        foreach (var inputGroup in inputGroups)
        {
            var cost = CalculateCost(new Configuration(inputGroup));

            if (cost != -1)
            {
                sumForPrizes += cost;
            }
        }

        return sumForPrizes;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var inputGroups = input.ToList().SplitByBlankLines();

        var sumForPrizes = 0L;

        foreach (var inputGroup in inputGroups)
        {
            var configuration = new Configuration(inputGroup);

            configuration.Prize = new Coordinate(configuration.Prize.X + 10000000000000, configuration.Prize.Y + 10000000000000);

            var cost = CalculateCost(configuration);

            if (cost != -1)
            {
                sumForPrizes += cost;
            }
        }

        return sumForPrizes;
    }

    private static long CalculateCost(Configuration config)
    {
        var d1 = config.Prize.Y * config.ButtonB.X - config.ButtonB.Y * config.Prize.X;
        var d2 = config.ButtonB.X * config.ButtonA.Y - config.ButtonA.X * config.ButtonB.Y;

        var aPresses = Math.DivRem(d1, d2, out var remainder);

        if (remainder != 0)
        {
            // We can't press partial buttons.
            return -1;
        }

        var bPresses = (config.Prize.X - config.ButtonA.X * aPresses) / config.ButtonB.X;

        // Verify the presses get us to the correct position.
        var location = new Coordinate(
            aPresses * config.ButtonA.X + bPresses * config.ButtonB.X,
            aPresses * config.ButtonA.Y + bPresses * config.ButtonB.Y);

        if (!location.Equals(config.Prize))
        {
            return -1;
        }

        // A button costs 3 tokens, B button costs 1 token.
        return (aPresses * 3) + (bPresses * 1);
    }

    private class Configuration
    {
        public Configuration(IList<string> input)
        {
            var buttonA = Regex.Match(input[0], @"Button A: X\+(?<x>\d+), Y\+(?<y>\d+)");
            var buttonB = Regex.Match(input[1], @"Button B: X\+(?<x>\d+), Y\+(?<y>\d+)");
            var prize = Regex.Match(input[2], @"Prize: X=(?<x>\d+), Y=(?<y>\d+)");

            ButtonA = new Vector(buttonA.Groups["x"].Value.ToInt(), buttonA.Groups["y"].Value.ToInt());
            ButtonB = new Vector(buttonB.Groups["x"].Value.ToInt(), buttonB.Groups["y"].Value.ToInt());
            Prize = new Coordinate(prize.Groups["x"].Value.ToInt(), prize.Groups["y"].Value.ToInt());
        }

        public Coordinate Prize { get; set; }

        public Vector ButtonA { get; }

        public Vector ButtonB { get; }
    }
}