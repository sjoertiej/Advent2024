using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class Day03
{

    public int Part1(string textFilePath)
    {
        Regex regex = new(@"mul\((\d+),(\d+)\)");

        var reader = new Readers();
        var corruptedMemory = reader.ReadAllText(textFilePath);

        var matches = regex.Matches(corruptedMemory);

        int sum = 0;
        foreach (Match match in matches)
        {
            int value1 = int.Parse(match.Groups[1].Value);
            int valu2 = int.Parse(match.Groups[2].Value);

            sum += value1 * valu2;;
        }
        return sum;
    }


    public int Part2(string textFilePath)
    {
        Regex regex = new(@"mul\((\d+),(\d+)\)|do\(\)|don't\(\)");

        var reader = new Readers();
        var corruptedMemory = reader.ReadAllText(textFilePath);

        var matches = regex.Matches(corruptedMemory);

        int sum = 0;
        bool execute = true;
        foreach (Match match in matches)
        {
            if (match.Value == "do()")
                execute = true;
            else if (match.Value == "don't()")
                execute = false;
            else
            {
                if (execute)
                {
                    int value1 = int.Parse(match.Groups[1].Value);
                    int valu2 = int.Parse(match.Groups[2].Value);
                    sum += value1 * valu2;;
                }
            }
        }
        return sum;
    }

}
