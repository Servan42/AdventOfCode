namespace AdventOfCode.Core
{
    public abstract class Exercise
    {
        public List<string> InputLines { get; set; } = new List<string>();
        public string Output { get; protected set; } = string.Empty;

        public void LoadInputFromFile(string fileName)
        {
            InputLines = File.ReadAllLines(fileName).ToList();
        }

        public void SaveOutputToFile(string fileName)
        {
            File.WriteAllText(fileName, Output);
        }

        public abstract void ComputePart1();
        public abstract void ComputePart2();
    }
}