using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
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
            var registers = new Dictionary<string, int>();
            foreach (var s in data.Where(s => s != ""))
            {
                var parts = s.Split(" ");
                var firstCondition = parts[4];
                var secondCondition = int.Parse(parts[6]);
                var skip = false;
                if (!registers.ContainsKey(firstCondition)) registers.Add(firstCondition, 0);
                switch (parts[5])
                {
                    case ">":
                        if (!(registers[firstCondition] > secondCondition)) skip = true;
                        break;
                    case "<":
                        if (!(registers[firstCondition] < secondCondition)) skip = true;
                        break;
                    case ">=":
                        if (!(registers[firstCondition] >= secondCondition)) skip = true;
                        break;
                    case "<=":
                        if (!(registers[firstCondition] <= secondCondition)) skip = true;
                        break;
                    case "==":
                        if (registers[firstCondition] != secondCondition) skip = true;
                        break;
                    case "!=":
                        if (registers[firstCondition] == secondCondition) skip = true;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }

                if (skip) continue;
                var register = parts[0];
                var action = parts[1];
                var amount = int.Parse(parts[2]);
                if (!registers.ContainsKey(register)) registers.Add(register, 0);
                switch (action)
                {
                    case "inc":
                        registers[register] += amount;
                        break;
                    case "dec":
                        registers[register] -= amount;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }

            }

            Console.WriteLine("Max value = " + registers.Max(r => r.Value));
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
