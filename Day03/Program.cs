using System;
using System.IO;
using System.Linq;

namespace Day03
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
            var data = int.Parse(input);
            var i = 1;
            while (Math.Pow(i, 2) < data)
            {
                i++;
            }

            var solution = i - 1 - (Math.Pow(i, 2) - data);
            Console.WriteLine("Answer = " + solution);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
