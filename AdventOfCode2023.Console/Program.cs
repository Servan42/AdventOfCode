using AdventOfCode2023.Core.Daily.Day7;

internal class Program
{
    /// <summary>
    /// https://adventofcode.com/
    /// </summary>
    private static void Main(string[] args)
    {
        var exercise = new Day7Ex();
        exercise.LoadInputFromFile("input.txt");
        exercise.ComputePart1();
        Console.WriteLine(exercise.Output);
        exercise.SaveOutputToFile("output.txt");
        Console.ReadKey();
    }
}