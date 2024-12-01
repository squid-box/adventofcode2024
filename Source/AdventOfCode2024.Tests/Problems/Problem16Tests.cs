namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem16Tests
{
    private static readonly string[] TestInput =
    [
        
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem16.PartOne(TestInput), Is.EqualTo(4711));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem16.PartTwo(TestInput), Is.EqualTo(4711));
    }
}