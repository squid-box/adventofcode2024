namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem3Tests
{
    private static readonly string[] TestInput1 =
    [
        "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"
    ];
    private static readonly string[] TestInput2 =
    [
        "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem3.PartOne(TestInput1), Is.EqualTo(161));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem3.PartTwo(TestInput2), Is.EqualTo(48));
    }
}