using System.ComponentModel.Design;

namespace AdventOfCode2024;

public class Day02
{

    public int Part2(string textFilePath)
    {
        var reports = GetReports(textFilePath);

        var amountOfSafeReports = 0;
        foreach (var report in reports)
        {
            var isReportSafe = CheckIfReportIsSafe(report);
            if (isReportSafe)
                amountOfSafeReports += 1;
            else
            {
                // Problem dampener
                // Try to fix it by looping through the list and deleting on item every time
                for (int i = 0; i < report.Count; i++)
                {
                    var updatedReport = new List<int>(report);
                    updatedReport.RemoveAt(i);
                    isReportSafe = CheckIfReportIsSafe(updatedReport);
                    if (isReportSafe)
                    {
                        amountOfSafeReports += 1;
                        break;
                    }
                }
            }
        }
        return amountOfSafeReports;
    }

// This function did not work completely
    public bool CheckIfReportIsSafeWithDampener(List<int> report)
    {
        int badLevels = 0;
        bool dampenerActivated = false;
        var myList = new List<string>();

        for (int i = 0; i < report.Count; i++)
        {
            if (i == 0)
                continue;

            int previousLevel;
            if (dampenerActivated)
            {
                previousLevel = report[i-2];
                dampenerActivated = false;
            }
            else
                previousLevel = report[i-1];

                var difference = Math.Abs(report[i] - previousLevel);

            if (report[i] > previousLevel)
                myList.Add("increase");
            if (report[i] < previousLevel)
                myList.Add("decrease");

            if (difference == 0 || difference > 3 || myList.Distinct().Count() > 1)
            {
                badLevels++;
                dampenerActivated = true;
                if (myList.Count > 0)
                    myList.RemoveAt(myList.Count - 1);
            }

            if (badLevels > 1)
                return false;
        }
        return true;
    }

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
