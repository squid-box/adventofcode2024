namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem11Tests
{
    private static readonly string[] TestInput =
    [
        "125 17"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem11.PartOne(TestInput), Is.EqualTo(55312));
    }
}