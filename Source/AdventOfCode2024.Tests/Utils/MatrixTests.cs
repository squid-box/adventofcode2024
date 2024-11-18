namespace AdventOfCode2024.Tests.Utils;

using System;

using AdventOfCode2024.Utils;

using NUnit.Framework;

[TestFixture]
public class MatrixTests
{
    [Test]
    public void ConstructorTests()
    {
        var squareMatrix = new Matrix<int>(10);

        Assert.That(squareMatrix.Width.Equals(10));
        Assert.That(squareMatrix.Height.Equals(10));

        var matrix = new Matrix<int>(5, 10);

        Assert.That(matrix.Width.Equals(5));
        Assert.That(matrix.Height.Equals(10));
    }

    [Test]
    public void GetElementTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.GetElement(-1, 5));
        Assert.That(matrix.GetElement(0, 0) == false);
    }

    [Test]
    public void SetElementTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.SetElement(-1, 5, true));
        Assert.That(matrix.GetElement(0, 0) == false);
        matrix.SetElement(0, 0, true);
        Assert.That(matrix.GetElement(0, 0));
    }

    [Test]
    public void GetRowTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.GetRow(-1));
        Assert.That(matrix.GetRow(0).Count.Equals(10));
    }

    [Test]
    public void GetColumnTests()
    {
        var matrix = new Matrix<bool>(10);

        Assert.Throws<IndexOutOfRangeException>(() => matrix.GetColumn(-1));
        Assert.That(matrix.GetColumn(0).Count.Equals(10));
    }
}