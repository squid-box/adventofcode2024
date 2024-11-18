namespace AdventOfCode2024.Tests.Utils;

using AdventOfCode2024.Utils;

using NUnit.Framework;

[TestFixture]
public class VectorTests
{
    [Test]
    public void VectorAddition()
    {
        var vectorOne = new Vector(0, 0, 0);
        var vectorTwo = new Vector(5, 6, 7);
        var vectorThree = new Vector(1, 2, 3);

        var resultOne = new Vector(6, 8, 10);

        Assert.That((vectorOne + vectorTwo).Equals(vectorTwo));
        Assert.That((vectorTwo + vectorThree).Equals(resultOne));
    }

    [Test]
    public void VectorSubtraction()
    {
        var vectorOne = new Vector(0, 0, 0);
        var vectorTwo = new Vector(5, 6, 7);
        var vectorThree = new Vector(1, 2, 3);

        var resultOne = new Vector(4, 4, 4);

        Assert.That((vectorTwo - vectorOne).Equals(vectorTwo));
        Assert.That((vectorTwo - vectorThree).Equals(resultOne));
    }
}