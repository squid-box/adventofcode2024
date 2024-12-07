namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem7Tests
{
    private static readonly string[] TestInput =
    [
        "190: 10 19",
        "3267: 81 40 27",
        "83: 17 5",
        "156: 15 6",
        "7290: 6 8 6 15",
        "161011: 16 10 13",
        "192: 17 8 14",
        "21037: 9 7 18 13",
        "292: 11 6 16 20"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem7.PartOne(TestInput), Is.EqualTo(3749));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem7.PartTwo(TestInput), Is.EqualTo(11387));
    }
}