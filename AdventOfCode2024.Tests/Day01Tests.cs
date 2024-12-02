using Xunit;
using Xunit.Abstractions;
using AdventOfCode2024;

namespace AdventOfCode2024.Tests;

public class Day01Tests
{
    [Fact]
    public void TestExample1()
    {
        var filePath = @"C:\GitHub\AdventOfCode2024\InputDocuments\day1_test_data.txt";
        var day01 = new Day01();
        var sum = day01.Part1(filePath);
        System.Diagnostics.Debug.WriteLine($"The sum is {sum}");
    }

    [Fact]
    public void TestPart1()
    {
        var filePath = @"C:\GitHub\AdventOfCode2024\InputDocuments\day1_part1.txt";
        var day01 = new Day01();
        var sum = day01.Part1(filePath);
        System.Diagnostics.Debug.WriteLine($"The sum is {sum}");
    }
}
