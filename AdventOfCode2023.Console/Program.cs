using AdventOfCode2023.Core.Daily.Day4;

internal class Program
{
    /// <summary>
    /// https://adventofcode.com/
    /// </summary>
    private static void Main(string[] args)
    {
        var exercise = new Day4Ex();
        exercise.LoadInputFromFile("input.txt");
        exercise.ComputePart2();
        Console.WriteLine(exercise.Output);
        exercise.SaveOutputToFile("output.txt");
    }
}