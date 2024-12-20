namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem6Tests
{
    private static readonly string[] TestInput =
    [
        "....#.....",
        ".........#",
        "..........",
        "..#.......",
        ".......#..",
        "..........",
        ".#..^.....",
        "........#.",
        "#.........",
        "......#..."
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem6.PartOne(TestInput), Is.EqualTo(41));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem6.PartTwo(TestInput), Is.EqualTo(6));
    }
}