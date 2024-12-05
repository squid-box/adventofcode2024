namespace AdventOfCode2024.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/5">Day 5</a>.
/// </summary>
public class Problem5(InputDownloader inputDownloader) : ProblemBase(5, inputDownloader)
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

        var rules = inputChunks[0]
            .Select(line => line.Split('|'))
            .Select(split => new Rule(split[0].ToInt(), split[1].ToInt()))
            .ToList();

        var sumOfCenterPages = 0;

        foreach (var update in inputChunks[1])
        {
            var pages = update.Split(',').AsInt();

            if (IsLineValid(pages, rules))
            {
                sumOfCenterPages += pages.GetCenterElement();
            }
        }

        return sumOfCenterPages;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var inputChunks = input.ToList().SplitByBlankLines();

        var rules = inputChunks[0]
            .Select(line => line.Split('|'))
            .Select(split => new Rule(split[0].ToInt(), split[1].ToInt()))
            .ToList();

        var sumOfCorrectedCenterPages = 0;

        foreach (var update in inputChunks[1])
        {
            var pages = update.Split(',').AsInt();

            if (IsLineValid(pages, rules))
            {
                continue;
            }

            do
            {
                foreach (var rule in rules)
                {
                    if (!pages.Contains(rule.AfterPage) || !pages.Contains(rule.BeforePage))
                    {
                        continue;
                    }

                    var indexOfBeforePage = pages.IndexOf(rule.BeforePage);
                    var indexofAfterPage = pages.IndexOf(rule.AfterPage);

                    if (indexofAfterPage < indexOfBeforePage)
                    {
                        pages[indexOfBeforePage] = rule.AfterPage;
                        pages[indexofAfterPage] = rule.BeforePage;
                    }
                }

            } while (!IsLineValid(pages, rules));

            sumOfCorrectedCenterPages += pages.GetCenterElement();
        }

        return sumOfCorrectedCenterPages;
    }

    private static bool IsLineValid(IList<int> pages, IList<Rule> rules)
    {
        foreach (var rule in rules)
        {
            if (!pages.Contains(rule.AfterPage) || !pages.Contains(rule.BeforePage))
            {
                continue;
            }

            var indexOfBeforePage = pages.IndexOf(rule.BeforePage);
            var indexofAfterPage = pages.IndexOf(rule.AfterPage);

            if (indexofAfterPage < indexOfBeforePage)
            {
                return false;
            }
        }

        return true;
    }

    private record Rule(int BeforePage, int AfterPage);
}