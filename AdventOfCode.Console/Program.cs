using AdventOfCode.Core.Daily2024.Day03;

internal class Program
{
    /// <summary>
    /// https://adventofcode.com/
    /// </summary>
    private static void Main(string[] args)
    {
        var exercise = new Day03Ex();
        exercise.LoadInputFromFile("input.txt");
        exercise.ComputePart2();
        Console.WriteLine(exercise.Output);
        exercise.SaveOutputToFile("output.txt");
        Console.ReadKey();
    }
}