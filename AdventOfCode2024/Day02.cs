namespace AdventOfCode2024;

public class Day02
{
    public int Part1(string textFilePath)
    {
        var reports = GetReports(textFilePath);

        var amountOfSafeReports = 0;
        foreach (var report in reports)
        {
            var isReportSafe = CheckIfReportIsSafe(report);
            if (isReportSafe)
                amountOfSafeReports += 1;
        }
        return amountOfSafeReports;
    }

    public bool CheckIfReportIsSafe(List<int> report)
    {
        bool isIncreasing = false;
        bool isDecreasing = false;
        for (int i = 0; i < report.Count; i++)
        {
            if (i == 0)
                continue;

            var difference = Math.Abs(report[i] - report[i-1]);
            if (difference == 0 || difference > 3)
                return false;

            if (report[i] > report[i-1])
                isIncreasing = true;
            if (report[i] < report[i-1])
                isDecreasing = true;

            if (isIncreasing && isDecreasing)
                return false;
        }
        return true;
    }

    public List<List<int>> GetReports(string textFilePath)
    {
        string[] reports = File.ReadAllLines(textFilePath);

        var reportsOut =  new List<List<int>>();
        foreach (var report in reports)
        {
            var levels = report.Split(" ");
            var levelsOut = new List<int>();
            foreach (var level in levels)
                levelsOut.Add(int.Parse(level));
            reportsOut.Add(levelsOut);
        }
        return reportsOut;
    }
}
