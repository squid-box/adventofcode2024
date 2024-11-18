namespace AdventOfCode2024.Tests.Utils.Extensions;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;
using NUnit.Framework;

[TestFixture]
public class CollectionExtensionsTests
{
    [TestCase(new[] {"1"}, new[] { 1 })]
    [TestCase(new[] {"1", "2", "3"}, new[] { 1, 2, 3 })]
    public void TestAsInt(ICollection<string> input, ICollection<int> expected)
    {
        Assert.That(input.AsInt().SequenceEqual(expected));
    }

    [TestCase(new[] { "1" }, new[] { 1L })]
    [TestCase(new[] { "1", "2", "3" }, new[] { 1L, 2L, 3L })]
    public void TestAsLong(ICollection<string> input, ICollection<long> expected)
    {
        Assert.That(input.AsLong().SequenceEqual(expected));
    }

    [TestCase(new[] { "" }, 0)]
    [TestCase(new[] { "A Line", "", "Another line" }, 2)]
    [TestCase(new[] { null, "A Line", "", "Another line" }, 2)]
    public void TestWithNoEmptyLines(ICollection<string> input, int expectedLines)
    {
        Assert.That(input.WithNoEmptyLines().Count.Equals(expectedLines));
    }

    [Test]
    public void TestSplitByBlankLines()
    {
        var inputOne = new List<string>
        {
            "Line",
            "Another line",
            "",
            "Third line"
        };

        Assert.That(inputOne.SplitByBlankLines().Count.Equals(2));

        var inputTwo = new List<string>
        {
            "Line",
            "Another line",
            "",
            "Third line",
            "",
            "",
            "Fourth line"
        };

        Assert.That(inputTwo.SplitByBlankLines().Count.Equals(3));
    }
}