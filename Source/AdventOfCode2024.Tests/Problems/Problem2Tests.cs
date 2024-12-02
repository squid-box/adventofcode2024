namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem2Tests
{
    private static readonly string[] TestInput =
    [
        "7 6 4 2 1",
        "1 2 7 8 9",
        "9 7 6 2 1",
        "1 3 2 4 5",
        "8 6 4 4 1",
        "1 3 6 7 9",
        "1 1 2 3 5"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem2.PartOne(TestInput), Is.EqualTo(2));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem2.PartTwo(TestInput), Is.EqualTo(5));
    }
}