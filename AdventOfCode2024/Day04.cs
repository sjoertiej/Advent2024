using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day04
{

    public int Part1(string textFilePath)
    {

        var word = "XMAS";

        var reader = new Readers();
        var grid = reader.ReadAllLines(textFilePath);

        int count = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;

        var directions = new int[][] {
            [0, 1],    // Right
            [0, -1],   // Left
            [1, 0],    // Down
            [-1, 0],   // Up
            [1, 1],    // Diagonal down-right
            [-1, -1],  // Diagonal up-left
            [1, -1],   // Diagonal down-left
            [-1, 1]    // Diagonal up-right
        };

        for (int i = 0; i < rows; i++)
        {
            // System.Diagnostics.Debug.WriteLine(i);
            for (int j = 0; j < cols; j++)
            {
                // System.Diagnostics.Debug.WriteLine($"{i}-{j}: {grid[i][j]}");

                foreach (var dir in directions)
                {
                    if (grid[i][j] == word[0])  // X
                    {
                        int l1i = i + 1 * dir[0];
                        int l1j = j + 1 * dir[1];
                        if (l1i < 0 || l1i >= rows || l1j < 0 || l1j >= cols)
                        {
                            continue;
                        }

                        if (grid[l1i][l1j] == word[1])  // M
                        {
                            int l2i = i + 2 * dir[0];
                            int l2j = j + 2 * dir[1];
                            if (l2i < 0 || l2i >= rows || l2j < 0 || l2j >= cols)
                            {
                                continue;
                            }

                            if (grid[l2i][l2j] == word[2])  // A
                            {
                                int l3i = i + 3 * dir[0];
                                int l3j = j + 3 * dir[1];
                                if (l3i < 0 || l3i >= rows || l3j < 0 || l3j >= cols)
                                {
                                    continue;
                                }

                                if (grid[l3i][l3j] == word[3])  // S
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }
        return count;
    }


    public int Part2(string textFilePath)
    {
        return 0;
    }

}
