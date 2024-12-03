namespace AdventOfCode2024.Problems;

using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/3">Day 3</a>.
/// </summary>
public class Problem3(InputDownloader inputDownloader) : ProblemBase(3, inputDownloader)
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
        var multiplierRegex = new Regex(@"mul\((?<numOne>\d{1,3}),(?<numTwo>\d{1,3})\)", RegexOptions.Compiled);

        var sum = 0;

        foreach (var line in input)
        {
            var matches = multiplierRegex.Matches(line);

            foreach (Match match in matches)
            {
                var numberOne = match.Groups["numOne"].Value.ToInt();
                var numberTwo = match.Groups["numTwo"].Value.ToInt();

                sum += numberTwo * numberOne;
            }
        }

        return sum;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var multiplierRegex = new Regex(@"(mul\((?<numOne>\d{1,3}),(?<numTwo>\d{1,3})\))|(?<do>do\(\))|(?<donot>don't\(\))", RegexOptions.Compiled);

        var sum = 0;

        var followInstructions = true;

        foreach (var line in input)
        {
            var matches = multiplierRegex.Matches(line);

            foreach (Match match in matches)
            {
                if (match.Groups["do"].Success)
                {
                    followInstructions = true;
                }
                else if (match.Groups["donot"].Success)
                {
                    followInstructions = false;
                }
                else if (followInstructions)
                {
                    var numberOne = match.Groups["numOne"].Value.ToInt();
                    var numberTwo = match.Groups["numTwo"].Value.ToInt();

                    sum += numberTwo * numberOne;
                }
            }
        }

        return sum;
    }
}