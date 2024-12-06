namespace AdventOfCode2024.Problems;

using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/6">Day 6</a>.
/// </summary>
public class Problem6(InputDownloader inputDownloader) : ProblemBase(6, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input);
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input);
    }

    public static object PartOne(IEnumerable<string> input)
    {
        var list = input.ToList();
        var width = list.First().Length;
        var height = list.Count;

        var map = new Matrix<char>(width, height);
        Guard guard = null;

        for (var y = 0; y < height; y++)
        {
            var line = list[y];

            for (var x = 0; x < width; x++)
            {
                switch (line[x])
                {
                    case '^':
                    case 'v':
                    case 'V':
                    case '<':
                    case '>':
                        guard = new Guard(line[x], new Coordinate(x, y));
                        break;
                }

                map[x, y] = line[x];
            }
        }

        if (guard == null)
        {
            throw new InvalidOperationException("No guard was found?");
        }

        WalkGuardThroughMap(guard, map);

        return guard.VisitedPositions.Count - 1;
    }

    private static bool WalkGuardThroughMap(Guard guard, Matrix<char> map)
    {
        var isGuardGone = false;

        do
        {
            var nextPosition = guard.Position + guard.Direction;

            if (!map.IsWithinBounds(nextPosition))
            {
                break;
            }

            while (map[nextPosition] == '#')
            {
                guard.RotateRight();
                nextPosition = guard.Position + guard.Direction;

                if (!map.IsWithinBounds(nextPosition))
                {
                    isGuardGone = true;
                    break;
                }
            }

            if (isGuardGone)
            {
                break;
            }

            if (guard.Move(nextPosition))
            {
                return true;
            }

        } 
        while (map.IsWithinBounds(guard.Position));

        return false;
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var list = input.ToList();
        var width = list.First().Length;
        var height = list.Count;

        var map = new Matrix<char>(width, height);
        Guard guard = null;

        for (var y = 0; y < height; y++)
        {
            var line = list[y];

            for (var x = 0; x < width; x++)
            {
                switch (line[x])
                {
                    case '^':
                    case 'v':
                    case 'V':
                    case '<':
                    case '>':
                        guard = new Guard(line[x], new Coordinate(x, y));
                        break;
                }

                map[x, y] = line[x];
            }
        }

        if (guard == null)
        {
            throw new InvalidOperationException("No guard was found?");
        }

        WalkGuardThroughMap(guard, map);

        var initialPath = guard.VisitedPositions;

        var numberOfPositionsCausingLoops = 0;

        foreach (var potentialPosition in initialPath)
        {
            guard.Reset();

            var newMap = map.Copy();
            newMap[potentialPosition] = '#';

            if (WalkGuardThroughMap(guard, newMap))
            {
                numberOfPositionsCausingLoops++;
            }
        }

        return numberOfPositionsCausingLoops;
    }

    private class Guard
    {
        private readonly Vector _originalDirection;
        private readonly Coordinate _originalPosition;

        private HashSet<Coordinate> _visitedCoordinates;
        private HashSet<(Coordinate, Vector)> _visitedCoordinatesWithDirection;

        public Guard(char initialDirection, Coordinate position)
        {
            _originalPosition = position;
            _originalDirection = initialDirection switch
            {
                '<' => Vector.West,
                '^' => Vector.North,
                '>' => Vector.East,
                'v' or 'V' => Vector.South,
                _ => throw new ArgumentException($"\"{initialDirection}\" is not a valid direction.")
            };

            Reset();
        }

        public void Reset()
        {
            _visitedCoordinates = new HashSet<Coordinate>();
            _visitedCoordinatesWithDirection = new HashSet<(Coordinate, Vector)>();

            Position = _originalPosition;
            Direction = _originalDirection;
        }

        public Vector Direction { get; private set; }

        public Coordinate Position { get; private set; }

        public List<Coordinate> VisitedPositions => _visitedCoordinates.ToList();

        public bool Move(Coordinate newPosition)
        {
            Position = newPosition;

            _visitedCoordinates.Add(Position);
            return !_visitedCoordinatesWithDirection.Add((Position, Direction));
        }

        public void RotateRight()
        {
            if (Direction.Equals(Vector.North))
            {
                Direction = Vector.East;
            }
            else if (Direction.Equals(Vector.West))
            {
                Direction = Vector.North;
            }
            else if (Direction.Equals(Vector.South))
            {
                Direction = Vector.West;
            }
            else if (Direction.Equals(Vector.East))
            {
                Direction = Vector.South;
            }
        }
    }
}