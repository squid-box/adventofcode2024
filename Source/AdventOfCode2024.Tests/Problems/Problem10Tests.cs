namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem10Tests
{
    private static readonly string[] TestInput =
    [
        "89010123",
        "78121874",
        "87430965",
        "96549874",
        "45678903",
        "32019012",
        "01329801",
        "10456732"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem10.PartOne(TestInput), Is.EqualTo(36));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem10.PartTwo(TestInput), Is.EqualTo(81));
    }
}