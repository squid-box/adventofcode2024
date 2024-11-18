namespace AdventOfCode2024.Tests.Utils;

using AdventOfCode2024.Utils;

using NUnit.Framework;

[TestFixture]
public class CoordinateTests
{
    [Test]
    public void CoordinateVectorInteraction()
    {
        var coordinate = new Coordinate(1, 2, 3);

        Assert.That(new Coordinate(1, 2, 4).Equals(coordinate + Vector.Up));
        Assert.That(new Coordinate(1, 2, 2).Equals(coordinate - Vector.Up));
    }

    [Test]
    public void ManhattanDistanceTest()
    {
        var start = Coordinate.Zero;

        var end = new Coordinate(10, 10);

        Assert.That(Coordinate.ManhattanDistance(start, start).Equals(0));
        Assert.That(Coordinate.ManhattanDistance(start, end).Equals(20));
        Assert.That(Coordinate.ManhattanDistance(end, start).Equals(20));
    }
}