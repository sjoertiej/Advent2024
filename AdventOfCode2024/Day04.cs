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

        for (int x = 0; x < rows; x++)
        {
            // System.Diagnostics.Debug.WriteLine(i);
            for (int y = 0; y < cols; y++)
            {
                // System.Diagnostics.Debug.WriteLine($"{i}-{j}: {grid[i][j]}");

                foreach (var dir in directions)
                {
                    if (grid[x][y] == word[0])  // X
                    {
                        int mX = x + 1 * dir[0];
                        int mY = y + 1 * dir[1];
                        if (mX < 0 || mX >= rows || mY < 0 || mY >= cols)
                        {
                            continue;
                        }

                        if (grid[mX][mY] == word[1])  // M
                        {
                            int aX = x + 2 * dir[0];
                            int aY = y + 2 * dir[1];
                            if (aX < 0 || aX >= rows || aY < 0 || aY >= cols)
                            {
                                continue;
                            }

                            if (grid[aX][aY] == word[2])  // A
                            {
                                int sX = x + 3 * dir[0];
                                int sY = y + 3 * dir[1];
                                if (sX < 0 || sX >= rows || sY < 0 || sY >= cols)
                                {
                                    continue;
                                }

                                if (grid[sX][sY] == word[3])  // S
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
