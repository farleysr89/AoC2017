using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day18
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
            long lastSoundPlayed = 0;
            long lastRecoveredSound = 0;
            var registers = new Dictionary<char, long>();
            for (long i = 0; i < data.Count; i++)
            {
                var s = data[(int)i];
                if (s == "") break;
                var parts = s.Split(" ");
                switch (parts[0])
                {
                    case "snd":
                        lastSoundPlayed = char.IsLower(parts[1][0]) ? registers[parts[1][0]] : long.Parse(parts[1]);
                        break;
                    case "set":
                        var setVal = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        if (registers.ContainsKey(parts[1][0])) registers[parts[1][0]] = setVal;
                        else registers.Add(parts[1][0], setVal);
                        break;
                    case "add":
                        var addVal = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        if (registers.ContainsKey(parts[1][0])) registers[parts[1][0]] += addVal;
                        else registers.Add(parts[1][0], addVal);
                        break;
                    case "mul":
                        var mulVal = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        if (registers.ContainsKey(parts[1][0])) registers[parts[1][0]] *= mulVal;
                        else registers.Add(parts[1][0], 0);
                        break;
                    case "mod":
                        var modVal = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        if (registers.ContainsKey(parts[1][0])) registers[parts[1][0]] %= modVal;
                        else registers.Add(parts[1][0], 0);
                        break;
                    case "rcv":
                        var rcvVal = char.IsLower(parts[1][0]) ? registers[parts[1][0]] : long.Parse(parts[1]);
                        if (rcvVal == 0)
                            break;
                        lastRecoveredSound = lastSoundPlayed;
                        if (lastRecoveredSound != 0)
                        {
                            Console.WriteLine("Last recovered sound = " + lastRecoveredSound);
                            return;
                        }
                        break;
                    case "jgz":
                        var jgzVal1 = char.IsLower(parts[1][0]) ? registers[parts[1][0]] : long.Parse(parts[1]);
                        var jgzVal2 = char.IsLower(parts[2][0]) ? registers[parts[2][0]] : long.Parse(parts[2]);
                        if (jgzVal1 > 0) i += jgzVal2 - 1;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }
            Console.WriteLine("Last recovered Sound = " + lastRecoveredSound);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
