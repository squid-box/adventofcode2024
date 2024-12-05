namespace AdventOfCode2024.Tests.Problems;

using AdventOfCode2024.Problems;
using NUnit.Framework;

[TestFixture]
public class Problem5Tests
{
    private static readonly string[] TestInput =
    [
        "47|53",
        "97|13",
        "97|61",
        "97|47",
        "75|29",
        "61|13",
        "75|53",
        "29|13",
        "97|29",
        "53|29",
        "61|53",
        "97|53",
        "61|29",
        "47|13",
        "75|47",
        "97|75",
        "47|61",
        "75|61",
        "47|29",
        "75|13",
        "53|13",
        "",
        "75,47,61,53,29",
        "97,61,53,29,13",
        "75,29,13",
        "75,97,47,61,53",
        "61,13,29",
        "97,13,75,29,47"
    ];

    [Test]
    public void TestPartOne()
    {
        Assert.That(Problem5.PartOne(TestInput), Is.EqualTo(143));
    }

    [Test]
    public void TestPartTwo()
    {
        Assert.That(Problem5.PartTwo(TestInput), Is.EqualTo(123));
    }
}