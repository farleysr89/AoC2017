using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
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
            var data = input.Split('\n')[0].Replace('\t', ' ').Split(" ").Select(int.Parse).ToList();
            var states = new HashSet<string> { string.Join("-", data.ToArray()) };
            var iterationCount = 0;
            while (true)
            {
                iterationCount++;
                var max = data.Max(b => b);
                var maxIndex = data.FindIndex(b => b == max);
                data[maxIndex] = 0;
                while (max > 0)
                {
                    max--;
                    maxIndex++;
                    if (maxIndex == data.Count) maxIndex = 0;
                    data[maxIndex]++;
                }
                var s = string.Join("-", data.ToArray());
                if (states.Contains(s)) break;
                states.Add(string.Join("-", data.ToArray()));
            }

            Console.WriteLine("Iteration Count = " + iterationCount);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n')[0].Replace('\t', ' ').Split(" ").Select(int.Parse).ToList();
            var states = new HashSet<string> { string.Join("-", data.ToArray()) };
            var iterationCount = 0;
            while (true)
            {
                iterationCount++;
                var max = data.Max(b => b);
                var maxIndex = data.FindIndex(b => b == max);
                data[maxIndex] = 0;
                while (max > 0)
                {
                    max--;
                    maxIndex++;
                    if (maxIndex == data.Count) maxIndex = 0;
                    data[maxIndex]++;
                }
                var s = string.Join("-", data.ToArray());
                if (states.Contains(s)) break;
                states.Add(string.Join("-", data.ToArray()));
            }

            var state = string.Join("-", data.ToArray());
            iterationCount = 0;
            while (true)
            {
                iterationCount++;
                var max = data.Max(b => b);
                var maxIndex = data.FindIndex(b => b == max);
                data[maxIndex] = 0;
                while (max > 0)
                {
                    max--;
                    maxIndex++;
                    if (maxIndex == data.Count) maxIndex = 0;
                    data[maxIndex]++;
                }
                var s = string.Join("-", data.ToArray());
                if (s == state) break;
            }

            Console.WriteLine("Iteration Count = " + iterationCount);
        }
    }
}
