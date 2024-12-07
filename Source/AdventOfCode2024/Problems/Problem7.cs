namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/7">Day 7</a>.
/// </summary>
public class Problem7(InputDownloader inputDownloader) : ProblemBase(7, inputDownloader)
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
        return FindSumOfLinesWithValidCombination(input, ['+', '*']);
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        return FindSumOfLinesWithValidCombination(input, ['+', '*', '|']);
    }

    private static long FindSumOfLinesWithValidCombination(IEnumerable<string> input, IList<char> operatorTypes)
    {
        var sumOfLinesWithValidCombination = 0L;

        foreach (var line in input)
        {
            var split = line.Split(':', StringSplitOptions.RemoveEmptyEntries);

            var controlNumber = split[0].ToLong();
            var numbers = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).AsLong();

            var operatorPermutations = GenerateOperatorCombinations(numbers.Count - 1, operatorTypes);

            foreach (var operators in operatorPermutations)
            {
                var ops = operators.ToArray();
                var result = numbers[0];

                for (var i = 0; i < numbers.Count - 1; i++)
                {
                    result = CalculateResult(result, numbers[i + 1], ops[i]);
                }

                if (result == controlNumber)
                {
                    sumOfLinesWithValidCombination += controlNumber;
                    break;
                }
            }
        }

        return sumOfLinesWithValidCombination;
    }

    private static long CalculateResult(long a, long b, char op)
    {
        return op switch
        {
            '+' => a + b,
            '*' => a * b,
            '|' => $"{a}{b}".ToLong(),
            _ => throw new ArgumentException($"Unknown operator: {op}", nameof(op))
        };
    }

    private static List<string> GenerateOperatorCombinations(long numberOfOperators, IList<char> operatorTypes)
    {
        var result = new List<string>();

        GenerateOperatorCombinationsInternal(string.Empty, numberOfOperators, result, operatorTypes);

        return result;
    }

    private static void GenerateOperatorCombinationsInternal(string current, long remaining, List<string> result, IList<char> operatorTypes)
    {
        if (remaining == 0)
        {
            result.Add(current);
            return;
        }

        foreach (var op in operatorTypes)
        {
            GenerateOperatorCombinationsInternal(current + op, remaining - 1, result, operatorTypes);
        }
    }
}