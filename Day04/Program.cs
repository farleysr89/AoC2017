using System;
using System.IO;
using System.Linq;

namespace Day04
{
    internal class Program
    {
        private static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        private static void SolvePart1()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var validCount = (from s in data.Where(s => s != "") select s.Split(" ") into words let hashedWords = words.ToHashSet() where words.Length == hashedWords.Count select words).Count();
            Console.WriteLine("Valid pass phrases count = " + validCount);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
