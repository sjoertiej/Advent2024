namespace AdventOfCode2024;

public class Readers
{

    public string[] ReadAllLines(string textFilePath)
    {
        return File.ReadAllLines(textFilePath);
    }

    public string ReadAllText(string textFilePath)
    {
        return File.ReadAllText(textFilePath);
    }

}
