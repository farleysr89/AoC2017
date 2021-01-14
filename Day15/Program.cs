using System;
using System.IO;
using System.Linq;

namespace Day15
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
            var a = long.Parse(data[0].Split(" ")[4]);
            var b = long.Parse(data[1].Split(" ")[4]);
            long aFactor = 16807;
            long bFactor = 48271;
            long divisor = 2147483647;
            long bits16 = 65536;

            var count = 0;
            for (var i = 0; i < 40000000; i++)
            {
                a *= aFactor;
                b *= bFactor;
                a %= divisor;
                b %= divisor;
                if (a % bits16 == b % bits16) count++;
            }
            Console.WriteLine("Count = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var a = long.Parse(data[0].Split(" ")[4]);
            var b = long.Parse(data[1].Split(" ")[4]);
            long aFactor = 16807;
            long bFactor = 48271;
            long divisor = 2147483647;
            long bits16 = 65536;

            var count = 0;
            for (var i = 0; i < 5000000; i++)
            {
                a *= aFactor;
                a %= divisor;
                while (a % 4 != 0)
                {
                    a *= aFactor;
                    a %= divisor;
                }
                b *= bFactor;
                b %= divisor;
                while (b % 8 != 0)
                {
                    b *= bFactor;
                    b %= divisor;
                }
                if (a % bits16 == b % bits16) count++;
            }
            Console.WriteLine("Count = " + count);
        }
    }
}
