namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem12Tests
{
    private static readonly string[] TestInput1 =
    [
        "OOOOO",
        "OXOXO",
        "OOOOO",
        "OXOXO",
        "OOOOO"
    ];

    private static readonly string[] TestInput2 =
    [
        "RRRRIICCFF",
        "RRRRIICCCF",
        "VVRRRCCFFF",
        "VVRCCCJFFF",
        "VVVVCJJCFE",
        "VVIVCCJJEE",
        "VVIIICJJEE",
        "MIIIIIJJEE",
        "MIIISIJEEE",
        "MMMISSJEEE"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem12.PartOne(TestInput1), Is.EqualTo(772));
        Assert.That(Problem12.PartOne(TestInput2), Is.EqualTo(1930));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem12.PartTwo(TestInput1), Is.EqualTo(4711));
    }
}