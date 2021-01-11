using System;
using System.IO;
using System.Linq;

namespace Day01
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
            var count = 0;
            var prev = '\0';
            foreach (var c in data[0])
            {
                if (prev == '\0') prev = c;
                else if (prev == c) count += int.Parse(c.ToString());
                prev = c;
            }

            if (prev == data[0][0]) count += int.Parse(prev.ToString());
            Console.WriteLine("Captcha Solution = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var count = 0;
            var inc = data[0].Length / 2;
            var index = 0;
            foreach (var c in data[0])
            {
                if (c == data[0][(index + inc) % data[0].Length]) count += int.Parse(c.ToString());
                index++;
            }

            Console.WriteLine("Captcha Solution = " + count);
        }
    }
}
