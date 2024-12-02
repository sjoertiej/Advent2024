using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public class Day01
    {
        public Regex regex = new(@"(\d+)\s+(\d+)");
        public int Part1(string textFilePath)
        {
            (List<int> firstList, List<int> secondList) = GetLists(textFilePath);

            var sum = 0;
            for (int i = 0; i < firstList.Count; i++)
            {
                var difference = Math.Abs(firstList[i] - secondList[i]);
                sum += difference;
            }

            return sum;
        }

        public int Part2(string textFilePath)
        {
            (List<int> firstList, List<int> secondList) = GetLists(textFilePath);

            var amountDict = new Dictionary<int, int>();
            // Create a dictionary from secondList to count the amounts
            foreach (int item in secondList)
            {
                if (!amountDict.ContainsKey(item))
                    amountDict[item] = 0;
                amountDict[item] += 1;
            }

            // Loop through firstList to get the sum
            var sum = 0;
            foreach (int item in firstList)
            {
                int amount;
                if (amountDict.ContainsKey(item))
                    amount = amountDict[item];
                else
                    amount = 0;

                sum += item * amount;
            }

            return sum;
        }

        private (List<int>, List<int>) GetLists(string textFilePath)
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

            return (firstList, secondList);
        }

    }
}