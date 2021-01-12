using System;
using System.IO;
using System.Linq;

namespace Day02
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
            var data = input.Split('\n').Select(s => s.Replace('\t', ' ')).ToList();
            var checkSum = data.Where(s => s != "").Select(s => s.Split(" ").Select(int.Parse)).Select(parts => parts.Max() - parts.Min()).Sum();
            Console.WriteLine("CheckSum = " + checkSum);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').Select(s => s.Replace('\t', ' ')).ToList();
            var checkSum = 0;
            foreach (var s in data.Where(s => s != ""))
            {
                var parts = s.Split(" ").Select(int.Parse);
                var found = false;
                foreach (var x in parts)
                {
                    foreach (var y in parts.Where(y => y != x))
                    {
                        if (x % y == 0)
                        {
                            found = true;
                            checkSum += x / y;
                            break;
                        }

                        if (y % x == 0)
                        {
                            found = true;
                            checkSum += y / x;
                            break;
                        }
                    }

                    if (found) break;
                }
            }
            Console.WriteLine("CheckSum = " + checkSum);
        }
    }
}
