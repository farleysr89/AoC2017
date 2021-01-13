using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
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
            var lengths = data[0].Split(",").Select(int.Parse);
            var skip = 0;
            var currPosition = 0;
            var nums = new List<int>();
            for (var i = 0; i <= 255; i++)
            {
                nums.Add(i);
            }

            foreach (var l in lengths)
            {
                var tmpArray = new int[l];
                for (var i = 0; i < l; i++)
                {
                    tmpArray[i] = nums[(currPosition + i) % nums.Count];
                }

                tmpArray = tmpArray.Reverse().ToArray();
                for (var i = 0; i < l; i++)
                {
                    nums[(currPosition + i) % nums.Count] = tmpArray[i];
                }
                currPosition += l + skip;
                currPosition %= nums.Count;
                skip++;
            }

            Console.WriteLine("Solution is " + nums[0] * nums[1]);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
