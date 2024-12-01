namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem1Tests
{
    private static readonly string[] TestInput =
    [
        "3   4",
        "4   3",
        "2   5",
        "1   3",
        "3   9",
        "3   3"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem1.PartOne(TestInput), Is.EqualTo(11));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem1.PartTwo(TestInput), Is.EqualTo(31));
    }
}