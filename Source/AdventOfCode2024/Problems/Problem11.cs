namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/11">Day 11</a>.
/// </summary>
public class Problem11(InputDownloader inputDownloader) : ProblemBase(11, inputDownloader)
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
        var stones = input.First().Split(' ', StringSplitOptions.RemoveEmptyEntries).AsLong();

        // [StoneNumber: Count]
        var stoneCount = new Dictionary<long, long>();

        foreach (var stone in stones)
        {
            if (!stoneCount.ContainsKey(stone))
            {
                stoneCount.Add(stone, 0);
            }

            stoneCount[stone]++;
        }

        for (var i = 0; i < 25; i++)
        {
            stoneCount = Blink(stoneCount);
        }

        var sum = 0L;

        foreach (var stoneNumber in stoneCount.Keys)
        {
            sum += stoneCount[stoneNumber];
        }

        return sum;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var stones = input.First().Split(' ', StringSplitOptions.RemoveEmptyEntries).AsLong();

        // [StoneNumber: Count]
        var stoneCount = new Dictionary<long, long>();

        foreach (var stone in stones)
        {
            if (!stoneCount.ContainsKey(stone))
            {
                stoneCount.Add(stone, 0);
            }

            stoneCount[stone]++;
        }

        for (var i = 0; i < 75; i++)
        {
            stoneCount = Blink(stoneCount);
        }

        var sum = 0L;

        foreach (var stoneNumber in stoneCount.Keys)
        {
            sum += stoneCount[stoneNumber];
        }

        return sum;
    }

    private static List<long> Blink(IList<long> stones)
    {
        var newOrder = new List<long>();

        for (var i = 0; i < stones.Count; i++)
        {
            if (stones[i] == 0)
            {
                newOrder.Add(1);
            }
            else if (stones[i].ToString().Length % 2 == 0)
            {
                var stringNumber = stones[i].ToString();
                var length = stringNumber.Length;

                newOrder.Add(Convert.ToInt64(stringNumber[..(length/2)]));
                newOrder.Add(Convert.ToInt64(stringNumber[(length/2)..]));
            }
            else
            {
                newOrder.Add(stones[i] * 2024);
            }
        }

        return newOrder;
    }

    private static Dictionary<long, long> Blink(Dictionary<long, long> stoneCount)
    {
        var newCount = new Dictionary<long, long>();

        foreach (var key in stoneCount.Keys)
        {
            if (key == 0)
            {
                if (!newCount.ContainsKey(1))
                {
                    newCount.Add(1, 0);
                }

                newCount[1] += stoneCount[key];
            }
            else if (key.ToString().Length % 2 == 0)
            {
                var stringNumber = key.ToString();
                var length = stringNumber.Length;

                var leftNumber = Convert.ToInt64(stringNumber[..(length / 2)]);
                var rightNumber = Convert.ToInt64(stringNumber[(length / 2)..]);

                if (!newCount.ContainsKey(leftNumber))
                {
                    newCount.Add(leftNumber, 0);
                }
                if (!newCount.ContainsKey(rightNumber))
                {
                    newCount.Add(rightNumber, 0);
                }

                newCount[leftNumber] += stoneCount[key];
                newCount[rightNumber] += stoneCount[key];
            }
            else
            {
                var newNumber = key * 2024;

                if (!newCount.ContainsKey(newNumber))
                {
                    newCount.Add(newNumber, 0);
                }

                newCount[newNumber] += stoneCount[key];
            }
        }

        return newCount;
    }
}