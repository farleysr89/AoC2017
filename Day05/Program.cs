using System;
using System.IO;
using System.Linq;

namespace Day05
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
            var data = input.Split('\n').Where(s => s != "").Select(int.Parse).ToList();
            var i = 0;
            var steps = 0;
            while (i < data.Count)
            {
                steps++;
                data[i]++;
                i += data[i] - 1;
            }
            Console.WriteLine("Steps taken = " + steps);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').Where(s => s != "").Select(int.Parse).ToList();
            var i = 0;
            var steps = 0;
            while (i < data.Count)
            {
                steps++;
                var tmp = data[i];
                data[i] += tmp > 2 ? -1 : 1;
                i += tmp;
            }
            Console.WriteLine("Steps taken = " + steps);
        }
    }
}
