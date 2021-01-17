using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day23
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
            var registers = new Dictionary<char, long>
            {
                { 'a', 0 },
                { 'b', 0 },
                { 'c', 0 },
                { 'd', 0 },
                { 'e', 0 },
                { 'f', 0 },
                { 'g', 0 },
                { 'h', 0 }
            };
            var mulCount = 0;
            for (long i = 0; i < data.Count; i++)
            {
                var s = data[(int)i];
                if (s == "") break;
                var parts = s.Split(" ");
                switch (parts[0])
                {
                    case "set":
                        var setVal = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        registers[parts[1][0]] = setVal;
                        break;
                    case "sub":
                        var subVal = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        registers[parts[1][0]] -= subVal;
                        break;
                    case "mul":
                        mulCount++;
                        var mulVal = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        registers[parts[1][0]] *= mulVal;
                        break;
                    case "jnz":
                        var jnzVal1 = char.IsLower(parts[1][0]) ? registers[parts[1][0]] : long.Parse(parts[1]);
                        var jnzVal2 = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        if (jnzVal1 != 0) i += jnzVal2 - 1;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }

            Console.WriteLine("Number of mul commands = " + mulCount);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
