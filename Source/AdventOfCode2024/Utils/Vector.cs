namespace AdventOfCode2024.Utils;

using System;

/// <summary>
/// Represents a vector in 2-4 dimensional space.
/// </summary>
/// <param name="x">The X component.</param>
/// <param name="y">The Y component.</param>
/// <param name="z">The Z component.</param>
/// <param name="w">The W component.</param>
public class Vector(long x, long y, long z = 0, long w = 0)
{
    /// <summary>
    /// Gets the X component of this <see cref="Vector"/>.
    /// </summary>
    public long X { get; } = x;

    /// <summary>
    /// Gets the Y component of this <see cref="Vector"/>.
    /// </summary>
    public long Y { get; } = y;

    /// <summary>
    /// Gets the Z component of this <see cref="Vector"/>.
    /// </summary>
    public long Z { get; } = z;

    /// <summary>
    /// Gets the W component of this <see cref="Vector"/>.
    /// </summary>
    public long W { get; } = w;

    /// <summary>
    /// Returns the magnitude of this Vector.
    /// </summary>
    public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));

    /// <summary>
    /// Adds the components of two <see cref="Vector"/>s.
    /// </summary>
    /// <param name="a">First <see cref="Vector"/> to use.</param>
    /// <param name="b">Second <see cref="Vector"/> to use.</param>
    /// <returns>A new <see cref="Vector"/> with the added components of the two parameters.</returns>
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }

    /// <summary>
    /// Subtracts the components of two <see cref="Vector"/>s.
    /// </summary>
    /// <param name="a">First <see cref="Vector"/> to use.</param>
    /// <param name="b">Second <see cref="Vector"/> to use.</param>
    /// <returns>A new <see cref="Vector"/> with the subtracted components of the two parameters.</returns>
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }

    /// <summary>
    /// Multiplies the components of a <see cref="Vector"/> with a scalar.
    /// </summary>
    /// <param name="vector"><see cref="Vector"/> to use.</param>
    /// <param name="scalar">Scalar to multiply <paramref name="vector"/> with.</param>
    /// <returns>A new <see cref="Vector"/> with the components multiplied with the given scalar.</returns>
    public static Vector operator *(Vector vector, int scalar)
    {
        return new Vector(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"({X},{Y},{Z},{W})";
    }

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        var other = (Vector)obj;

        if (other == null)
        {
            return false;
        }

        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
    }

    /// <summary>
    /// Gets a vector representing moving one step north.
    /// </summary>
    public static Vector North => new(0, -1);

    /// <summary>
    /// Gets a vector representing moving one step south.
    /// </summary>
    public static Vector South => new(0, 1);

    /// <summary>
    /// Gets a vector representing moving one step west.
    /// </summary>
    public static Vector West => new(-1, 0);

    /// <summary>
    /// Gets a vector representing moving one step east.
    /// </summary>
    public static Vector East => new(1, 0);

    /// <summary>
    /// Gets a vector representing moving one step up.
    /// </summary>
    public static Vector Up => new(0, 0, 1);

    /// <summary>
    /// Gets a vector representing moving one step down.
    /// </summary>
    public static Vector Down => new(0, 0, -1);

    /// <summary>
    /// Gets a vector representing moving one step "hyper north".
    /// </summary>
    public static Vector HyperNorth => new(0, 0, 0, 1);

    /// <summary>
    /// Gets a vector representing moving one step "hyper south".
    /// </summary>
    public static Vector HyperSouth => new(0, 0, 0, -1);

    /// <summary>
    /// Gets the vectors for the cardinal directions.
    /// </summary>
    public static Vector[] CardinalVectors =
    [
        West, 
        North, 
        East, 
        South
    ];

    /// <summary>
    /// Gets the vectors for the two-dimensional directions.
    /// </summary>
    public static Vector[] AllTwoDimensionalVectors =
    [
        West, North, East, South,
        North + West,
        North + East,
        South + West,
        South + East
    ];
}