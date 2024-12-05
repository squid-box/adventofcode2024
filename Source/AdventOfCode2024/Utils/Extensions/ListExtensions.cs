namespace AdventOfCode2024.Utils.Extensions;

using System;
using System.Collections.Generic;

/// <summary>
/// Extensions for list.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Gets the element from the center of the list.
    /// </summary>
    /// <param name="input">The list to get the center element from.</param>
    /// <returns>The element at the center of the given list.</returns>
    /// <exception cref="InvalidOperationException" />
    public static T GetCenterElement<T>(this IList<T> input)
    {
        if (input == null || input.Count == 0)
        {
            throw new InvalidOperationException("List is null or empty, there is no center index.");
        }

        if (input.Count % 2 == 0)
        {
            throw new InvalidOperationException("List has an even number of elements, no single center element can be returned.");
        }

        return input[(int)Math.Floor(input.Count / 2d)];
    }
}