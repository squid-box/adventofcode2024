namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem3Tests
{
    private static readonly string[] TestInput =
    [
        
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem3.PartOne(TestInput), Is.EqualTo(4711));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem3.PartTwo(TestInput), Is.EqualTo(4711));
    }
}