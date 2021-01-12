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
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
