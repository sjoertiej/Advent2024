using Xunit;
using Xunit.Abstractions;
using AdventOfCode2024;

namespace AdventOfCode2024.Tests;

public class Day02Tests
{
    [Fact]
    public void TestExample1()
    {
        var filePath = @"C:\GitHub\AdventOfCode2024\InputDocuments\day2_test_data.txt";
        var day02 = new Day02();
        var sum = day02.Part1(filePath);
        System.Diagnostics.Debug.WriteLine($"The sum is {sum}");
    }

    [Fact]
    public void TestPart1()
    {
        var filePath = @"C:\GitHub\AdventOfCode2024\InputDocuments\day2_input.txt";
        var day02 = new Day02();
        var sum = day02.Part1(filePath);
        System.Diagnostics.Debug.WriteLine($"The sum is {sum}");
    }

    [Fact]
    public void TestExample2()
    {
        var filePath = @"C:\GitHub\AdventOfCode2024\InputDocuments\day2_test_data.txt";
        var day02 = new Day02();
        var sum = day02.Part2(filePath);
        System.Diagnostics.Debug.WriteLine($"The sum is {sum}");
    }

    [Fact]
    public void TestPart2()
    {
        var filePath = @"C:\GitHub\AdventOfCode2024\InputDocuments\day2_input.txt";
        var day02 = new Day02();
        var sum = day02.Part2(filePath);
        System.Diagnostics.Debug.WriteLine($"The sum is {sum}");
    }
}
