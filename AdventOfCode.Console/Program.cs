using AdventOfCode.Core.Daily2024.Day07;
using System.Diagnostics;

internal class Program
{
    /// <summary>
    /// https://adventofcode.com/
    /// </summary>
    private static void Main(string[] args)
    {
        var exercise = new Day07Ex();

        exercise.LoadInputFromFile("input.txt");
        Stopwatch sw = Stopwatch.StartNew();
        exercise.ComputePart1();
        var output1 = exercise.Output;
        Console.WriteLine(exercise.Output);
        Console.WriteLine(sw.Elapsed);

        exercise = new();
        exercise.LoadInputFromFile("input.txt");
        sw.Restart();
        exercise.ComputePart2();
        var output2 = exercise.Output;
        Console.WriteLine(exercise.Output);
        Console.WriteLine(sw.Elapsed);

        File.WriteAllText("output.txt", $"{output1}\n{output2}");
        Console.ReadKey();
    }
}