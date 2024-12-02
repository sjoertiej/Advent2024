using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public class Day01
    {
        public Regex regex = new(@"(\d+)\s+(\d+)");
        public int Part1(string textFilePath)
        {
            string[] lines = File.ReadAllLines(textFilePath);

            var firstList = new List<int>();
            var secondList = new List<int>();
            foreach (var line in lines)
            {
                var match = regex.Match(line);

                if (!match.Success)
                {
                    System.Diagnostics.Debug.WriteLine($"Match failed for {line}");
                    continue;
                }

                bool firstSuccess = int.TryParse(match.Groups[1].Value, out int firstNumber);
                bool secondSuccess = int.TryParse(match.Groups[2].Value, out int secondNumber);
                if (!firstSuccess || !secondSuccess)
                {
                    System.Diagnostics.Debug.WriteLine($"Parsing failed for one of the numbers in {line}");
                    continue;
                }

                firstList.Add(firstNumber);
                secondList.Add(secondNumber);
            }

            firstList.Sort();
            secondList.Sort();

            var sum = 0;
            for (int i = 0; i < firstList.Count; i++)
            {
                var difference = Math.Abs(firstList[i] - secondList[i]);
                sum += difference;
            }

            return sum;
        }
    }
}