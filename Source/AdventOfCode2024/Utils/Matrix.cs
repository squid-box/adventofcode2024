﻿namespace AdventOfCode2024.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Simple matrix wrapper.
/// </summary>
/// <typeparam name="T">Type used within the <see cref="Matrix{T}"/>.</typeparam>
public class Matrix<T>
{
    private readonly Dictionary<Coordinate, T> _matrix;

    private readonly bool _isFixedSize;

    /// <summary>
    /// Creates a new <see cref="Matrix{T}"/> with the given dimensions.
    /// </summary>
    public Matrix()
    {
        _matrix = new Dictionary<Coordinate, T>();
        _isFixedSize = false;
    }

    /// <summary>
    /// Creates a new <see cref="Matrix{T}"/> with the given dimensions.
    /// </summary>
    /// <param name="width">Width of the matrix.</param>
    /// <param name="height">Height of the matrix.</param>
    public Matrix(long width, long height)
    {
        Width = width;
        Height = height;

        _matrix = new Dictionary<Coordinate, T>();
        _isFixedSize = true;
    }

    /// <summary>
    /// Creates a new square <see cref="Matrix{T}"/> with the given size.
    /// </summary>
    /// <param name="size">Width and height of the matrix.</param>
    public Matrix(long size)
    {
        Width = size;
        Height = size;

        _matrix = new Dictionary<Coordinate, T>();
        _isFixedSize = true;
    }

    /// <summary>
    /// Width of the <see cref="Matrix{T}"/>.
    /// </summary>
    public long Width { get; private set; }

    /// <summary>
    /// Height of the <see cref="Matrix{T}"/>.
    /// </summary>
    public long Height { get; private set; }

    public T this[Coordinate key]
    {
        get => GetElement(key);
        set => SetElement(key, value);
    }

    public T this[int x, int y]
    {
        get => GetElement(x, y);
        set => SetElement(x, y, value);
    }

    public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
    {
        var result = new Matrix<T>(a.Width, a.Height);

        for (var y = 0; y < result.Height; y++)
        {
            for (var x = 0; x < result.Width; x++)
            {
                var coordinate = new Coordinate(x, y);
                result[coordinate] = Sum(a[coordinate], b[coordinate]);
            }
        }

        return result;
    }

    public Matrix<T> Copy()
    {
        var newMatrix = new Matrix<T>(Width, Height);

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                newMatrix[x, y] = GetElement(x, y);
            }
        }

        return newMatrix;
    }

    private static T Sum(T a, T b)
    {
        return (dynamic)a + (dynamic)b;
    }

    public Matrix<T> Transpose()
    {
        var result = new Matrix<T>(Height, Width);

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                result.SetElement(y, x, GetElement(x, y)); 
            }
        }

        return result;
    }

    public (Matrix<T> top, Matrix<T> bottom) SplitHorizontally(int y)
    {
        var top = new Matrix<T>(Width, y);
        var bottom = new Matrix<T>(Width, Height-y);

        for (var row = 0; row < Height; row++)
        {
            if (row < y)
            {
                top.SetRow(row, GetRow(row));
            }
            else
            {
                bottom.SetRow(row-y, GetRow(row));
            }
        }

        return (top, bottom);
    }

    public (Matrix<T> left, Matrix<T> right) SplitVertically(int x)
    {
        var left = new Matrix<T>(x, Height);
        var right = new Matrix<T>(Width-x, Height);

        for (var column = 0; column < Height; column++)
        {
            if (column < x)
            {
                left.SetColumn(column, GetColumn(column));
            }
            else
            {
                right.SetColumn(column - x, GetColumn(column));
            }
        }

        return (left, right);
    }

    /// <summary>
    /// Gets the element stored at the given coordinate.
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public T GetElement(Coordinate coordinate)
    {
        EvaluateGivenIndices(coordinate.X, coordinate.Y);

        return _matrix.ContainsKey(coordinate) ? _matrix[coordinate] : default;
    }

    public Matrix<T> MirrorHorizontally()
    {
        var result = new Matrix<T>(Width, Height);

        for (var y = 0; y < Height; y++)
        {
            result.SetRow(Height - y, GetRow(y));
        }

        return result;
    }

    public Matrix<T> MirrorVertically()
    {
        var result = new Matrix<T>(Width, Height);

        for (var x = 0; x < Width; x++)
        {
            result.SetColumn(Width - x, GetColumn(x));
        }

        return result;
    }

    /// <summary>
    /// Gets the element stored at (<paramref name="x"/>,<paramref name="y"/>).
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public T GetElement(long x, long y)
    {
        return GetElement(new Coordinate(x, y));
    }

    public IList<(Coordinate Position, T Element)> GetElements()
    {
        var result = new List<(Coordinate,T)>();

        foreach (var (p, e) in _matrix)
        {
            result.Add((p, e));
        }

        return result;
    }

    public int Count(Func<T, bool> filter = null)
    {
        return _matrix.Values.Where(filter ?? (_ => true)).Count();
    }

    /// <summary>
    /// Sets the given element at the given coordinate.
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public void SetElement(Coordinate coordinate, T value)
    {
        EvaluateGivenIndices(coordinate.X, coordinate.Y);

        if (!_isFixedSize && coordinate.X + 1 > Width)
        {
            Width = coordinate.X + 1;
        }

        if (!_isFixedSize && coordinate.Y + 1 > Height)
        {
            Height = coordinate.Y + 1;
        }

        _matrix[coordinate] = value;
    }

    /// <summary>
    /// Sets the given element at (<paramref name="x"/>,<paramref name="y"/>).
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public void SetElement(long x, long y, T value)
    {
        SetElement(new Coordinate(x, y), value);
    }

    /// <summary>
    /// Gets all elements on the given row.
    /// </summary>
    /// <param name="y">Zero-indexed row number.</param>
    /// <returns>All elements from given row.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public IList<T> GetRow(long y)
    {
        EvaluateGivenIndices(0, y);

        var result = new List<T>();

        for (var x = 0; x < Width; x++)
        {
            result.Add(GetElement(x, y));
        }

        return result;
    }

    public void SetRow(long y, IList<T> values)
    {
        EvaluateGivenIndices(0, y);
        
        if (values.Count != Width)
        {
            throw new DataMisalignedException("Given row is not the correct size.");
        }

        for (var x = 0; x < Width; ++x)
        {
            SetElement(x, y, values[x]);
        }
    }

    /// <summary>
    /// Gets all elements in the given column.
    /// </summary>
    /// <param name="x">Zero-indexed column number.</param>
    /// <returns>All elements from given column.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if any index is out of range.</exception>
    public IList<T> GetColumn(long x)
    {
        EvaluateGivenIndices(x, 0);

        var result = new List<T>();

        for (var y = 0; y < Height; y++)
        {
            result.Add(GetElement(x, y));
        }

        return result;
    }

    public void SetColumn(long x, IList<T> values)
    {
        EvaluateGivenIndices(x, 0);

        if (values.Count != Height)
        {
            throw new DataMisalignedException("Given column is not the correct size.");
        }

        for (var y = 0; y < Width; ++y)
        {
            SetElement(x, y, values[y]);
        }
    }

    /// <summary>
    /// Determines if given coordinate is within the matrix bounds.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <returns>True if within bounds, otherwise false.</returns>
    public bool IsWithinBounds(long x, long y)
    {
        return x.IsWithin(0, Width) &&
               y.IsWithin(0, Height);
    }

    /// <summary>
    /// Determines if given coordinate is within the matrix bounds.
    /// </summary>
    /// <param name="coordinate">The coordinate.</param>
    /// <returns>True if within bounds, otherwise false.</returns>
    public bool IsWithinBounds(Coordinate coordinate)
    {
        return coordinate.X.IsWithin(0, Width) &&
               coordinate.Y.IsWithin(0, Height);
    }

    private void EvaluateGivenIndices(long x, long y)
    {
        if (!x.IsWithin(0, Width))
        {
            throw new IndexOutOfRangeException($"Given index (x = {x}) not within matrix bounds.");
        }
        if (!y.IsWithin(0, Height))
        {
            throw new IndexOutOfRangeException($"Given index (y = {y}) not within matrix bounds.");
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder();

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                sb.Append(GetElement(x, y));
            }

            sb.Remove(sb.Length - 1, 1);
            sb.AppendLine();
        }

        return sb.ToString();
    }
}