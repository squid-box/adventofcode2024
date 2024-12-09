namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem9Tests
{
    private static readonly string[] TestInput =
    [
        "2333133121414131402"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem9.PartOne(TestInput), Is.EqualTo(1928));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem9.PartTwo(TestInput), Is.EqualTo(2858));
    }
}