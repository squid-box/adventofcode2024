namespace AdventOfCode2024.Tests;

using System;
using NUnit.Framework;

[TestFixture]
public class ResultTests
{
    [Test]
    public void Constructor_SetsDayProperty()
    {
        var sut = new Result(1);
        
        Assert.That(sut.Day.Equals(1));
    }

    [Test]
    public void FullAnswer_FirstAnswerOnly()
    {
        var sut = new Result(0)
        {
            AnswerPartOne = "Hello"
        };

        Assert.That(string.Equals(sut.FullAnswer, "Hello", StringComparison.Ordinal));
    }

    [Test]
    public void FullAnswer_SecondAnswerOnly()
    {
        var sut = new Result(0)
        {
            AnswerPartTwo = "World"
        };

        Assert.That(string.Equals(sut.FullAnswer, "World", StringComparison.Ordinal));
    }

    [Test]
    public void FullAnswer_BothAnswers()
    {
        var sut = new Result(0)
        {
            AnswerPartOne = "Hello",
            AnswerPartTwo = "World"
        };

        Assert.That(string.Equals(sut.FullAnswer, "Hello | World", StringComparison.Ordinal));
    }
}