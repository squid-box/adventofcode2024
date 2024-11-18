namespace AdventOfCode2024.Tests.Utils.Extensions;

using System;

using AdventOfCode2024.Utils.Extensions;

using NUnit.Framework;

[TestFixture]
public class StringExtensionsTests
{
    [TestCase("0", 0)]
    [TestCase("-10", -10)]
    [TestCase("666", 666)]
    public void Test(string source, int expectedResult)
    {
        Assert.That(source.ToInt().Equals(expectedResult));
    }

    [TestCase("0", 0L)]
    [TestCase("-10", -10L)]
    [TestCase("6000000000", 6000000000L)]
    public void Test(string source, long expectedResult)
    {
        Assert.That(source.ToLong().Equals(expectedResult));
    }

    [Test]
    public void LongToInt_Throws()
    {
        Assert.Throws<OverflowException>(() => "6000000000".ToInt());
    }

    [Test]
    public void BadString_Throws()
    {
        Assert.Throws<FormatException>(() => "hello".ToInt());
    }
}