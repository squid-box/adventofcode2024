namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem8Tests
{
    private static readonly string[] TestInput1 =
    [
        "............",
        "........0...",
        ".....0......",
        ".......0....",
        "....0.......",
        "......A.....",
        "............",
        "............",
        "........A...",
        ".........A..",
        "............",
        "............"
    ];

    private static readonly string[] TestInput2 =
    [
        "..........",
        "..........",
        "..........",
        "....a.....",
        "..........",
        ".....a....",
        "..........",
        "..........",
        "..........",
        ".........."
    ];

    private static readonly string[] TestInput3 =
    [
        "T.........",
        "...T......",
        ".T........",
        "..........",
        "..........",
        "..........",
        "..........",
        "..........",
        "..........",
        ".........."
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem8.PartOne(TestInput2), Is.EqualTo(2));
        Assert.That(Problem8.PartOne(TestInput1), Is.EqualTo(14));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem8.PartTwo(TestInput3), Is.EqualTo(9));
        Assert.That(Problem8.PartTwo(TestInput1), Is.EqualTo(34));
    }
}