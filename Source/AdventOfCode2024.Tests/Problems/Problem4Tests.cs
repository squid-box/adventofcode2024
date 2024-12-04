namespace AdventOfCode2024.Tests.Problems;

using System.Linq;
using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem4Tests
{
    private static readonly string[] TestInput =
    [
        "MMMSXXMASM",
        "MSAMXMSMSA",
        "AMXSXMAAMM",
        "MSAMASMSMX",
        "XMASAMXAMM",
        "XXAMMXXAMA",
        "SMSMSASXSS",
        "SAXAMASAAA",
        "MAMMMXMMMM",
        "MXMXAXMASX"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem4.PartOne(TestInput), Is.EqualTo(18));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem4.PartTwo(TestInput), Is.EqualTo(9));
    }
}