namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem12Tests
{
    private static readonly string[] TestInput =
    [
        
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem12.PartOne(TestInput), Is.EqualTo(4711));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem12.PartTwo(TestInput), Is.EqualTo(4711));
    }
}