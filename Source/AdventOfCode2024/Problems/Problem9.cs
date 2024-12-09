namespace AdventOfCode2024.Problems;

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2024.Utils.Extensions;

/// <summary>
/// Solution for <a href="https://adventofcode.com/2024/day/9">Day 9</a>.
/// </summary>
public class Problem9(InputDownloader inputDownloader) : ProblemBase(9, inputDownloader)
{
    /// <inheritdoc />
    protected override object SolvePartOne()
    {
        return PartOne(Input.WithNoEmptyLines());
    }

    /// <inheritdoc />
    protected override object SolvePartTwo()
    {
        return PartTwo(Input.WithNoEmptyLines());
    }

    public static object PartOne(IEnumerable<string> input)
    {
        var fileSystem = ParseDiskMap(input);

        FragmentFileSystem(fileSystem);

        return CalculateFileSystemChecksum(fileSystem);
    }

    public static object PartTwo(IEnumerable<string> input)
    {
        var fileSystem = ParseDiskMap(input);

        DeFragmentFileSystem(fileSystem);

        return CalculateFileSystemChecksum(fileSystem);
    }

    private static List<int> ParseDiskMap(IEnumerable<string> map)
    {
        var diskMap = new List<int>();

        foreach (var c in map.First())
        {
            diskMap.Add(c.ToString().ToInt());
        }

        var fileSystem = new List<int>();

        var isFreeSpace = false;

        var id = 0;

        for (var i = 0; i < diskMap.Count; i++)
        {
            var length = diskMap[i];

            if (isFreeSpace)
            {
                fileSystem.AddRange(Enumerable.Repeat(-1, length));
            }
            else
            {
                fileSystem.AddRange(Enumerable.Repeat(id, length));
                id++;
            }

            isFreeSpace = !isFreeSpace;
        }

        return fileSystem;
    }

    private static void FragmentFileSystem(List<int> fileSystem)
    {
        for (var index = fileSystem.Count - 1; index >= 0; index--)
        {
            var currentFragment = fileSystem[index];

            if (currentFragment == -1)
            {
                continue;
            }

            var firstFreeIndex = fileSystem.FindIndex(v => v == -1);

            if (firstFreeIndex == -1 || firstFreeIndex >= index)
            {
                // We can't move anything more to the left.
                break;
            }

            fileSystem[index] = -1;
            fileSystem[firstFreeIndex] = currentFragment;
        }
    }

    private static void DeFragmentFileSystem(List<int> fileSystem)
    {
        var lastId = fileSystem.Max();

        for (var id = lastId; id >= 0; id--)
        {
            var firstIndexOfId = fileSystem.FindIndex(v => v == id);
            var lastIndexOfId = fileSystem.FindLastIndex(v => v == id);

            var length = lastIndexOfId - firstIndexOfId + 1;

            // Find the first space which is big enough.
            for (var i = 0; i < firstIndexOfId; i++)
            {
                var currentBlock = fileSystem[i];

                if (currentBlock == -1)
                {
                    var endOfFreeSpaceIndex = fileSystem.FindIndex(i + 1, v => v != -1);

                    if (endOfFreeSpaceIndex - i >= length)
                    {
                        // We can move the file here.
                        for (var n = 0; n < length; n++)
                        {
                            fileSystem[i + n] = fileSystem[firstIndexOfId + n];
                            fileSystem[firstIndexOfId + n] = -1;
                        }

                        break;
                    }
                }
            }
        }
    }

    private static long CalculateFileSystemChecksum(List<int> fileSystem)
    {
        var checksum = 0L;

        for (var i = 0; i < fileSystem.Count; i++)
        {
            if (fileSystem[i] == -1)
            {
                continue;
            }

            checksum += i * fileSystem[i];
        }

        return checksum;
    }
}