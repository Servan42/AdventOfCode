using AdventOfCode.Core.Daily2023.Day25;

internal class Program
{
    /// <summary>
    /// https://adventofcode.com/
    /// </summary>
    private static void Main(string[] args)
    {
        var exercise = new Day25Ex();
        exercise.LoadInputFromFile("input.txt");
        exercise.ComputePart1();
        Console.WriteLine(exercise.Output);
        exercise.SaveOutputToFile("output.txt");
        Console.ReadKey();
    }
}