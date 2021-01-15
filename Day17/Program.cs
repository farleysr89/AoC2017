using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
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
            var output = new List<int> { 0 };
            var position = 0;
            for (var i = 1; i <= 2017; i++)
            {
                position = (position + data) % output.Count;
                output.Insert(position, i);
                position++;
            }
            Console.WriteLine("Next num is " + output[output.IndexOf(2017) + 1]);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
