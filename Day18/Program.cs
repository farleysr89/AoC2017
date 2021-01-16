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
                        if (lastSoundPlayed != 0)
                        {
                            Console.WriteLine("Last recovered sound = " + lastSoundPlayed);
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

            Console.WriteLine("Something Broke!");
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var registersZero = new Dictionary<char, long>
            {
                {'p', 0}
            };
            var registersOne = new Dictionary<char, long>
            {
                {'p', 1}
            };
            var queueZero = new Queue<long>();
            var queueOne = new Queue<long>();
            var runningZero = true;
            long indexZero = 0;
            long indexOne = 0;
            long sentCount = 0;
            var change = 0;
            while (change < 2)
            {
                if (runningZero)
                {
                    var s = data[(int)indexZero];
                    if (s == "") break;
                    var parts = s.Split(" ");
                    switch (parts[0])
                    {
                        case "snd":
                            var sndVal = char.IsLower(parts[1][0]) ? registersZero[parts[1][0]] : long.Parse(parts[1]);
                            queueOne.Enqueue(sndVal);
                            break;
                        case "set":
                            var setVal = char.IsLower(parts[2][0]) ? registersZero[parts[2][0]] : long.Parse(parts[2]);
                            if (registersZero.ContainsKey(parts[1][0])) registersZero[parts[1][0]] = setVal;
                            else registersZero.Add(parts[1][0], setVal);
                            break;
                        case "add":
                            var addVal = char.IsLower(parts[2][0]) ? registersZero[parts[2][0]] : long.Parse(parts[2]);
                            if (registersZero.ContainsKey(parts[1][0])) registersZero[parts[1][0]] += addVal;
                            else registersZero.Add(parts[1][0], addVal);
                            break;
                        case "mul":
                            var mulVal = char.IsLower(parts[2][0]) ? registersZero[parts[2][0]] : long.Parse(parts[2]);
                            if (registersZero.ContainsKey(parts[1][0])) registersZero[parts[1][0]] *= mulVal;
                            else registersZero.Add(parts[1][0], 0);
                            break;
                        case "mod":
                            var modVal = char.IsLower(parts[2][0]) ? registersZero[parts[2][0]] : long.Parse(parts[2]);
                            if (registersZero.ContainsKey(parts[1][0])) registersZero[parts[1][0]] %= modVal;
                            else registersZero.Add(parts[1][0], 0);
                            break;
                        case "rcv":
                            if (queueZero.Count == 0) runningZero = false;
                            else registersZero[parts[1][0]] = queueZero.Dequeue();
                            break;
                        case "jgz":
                            var jgzVal1 = char.IsLower(parts[1][0]) ? registersZero[parts[1][0]] : long.Parse(parts[1]);
                            var jgzVal2 = char.IsLower(parts[2][0]) ? registersZero[parts[2][0]] : long.Parse(parts[2]);
                            if (jgzVal1 > 0) indexZero += jgzVal2 - 1;
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            break;
                    }

                    if (runningZero)
                    {
                        indexZero++;
                        change = 0;
                    }
                    else change++;
                }
                else
                {
                    var s = data[(int)indexOne];
                    if (s == "") break;
                    var parts = s.Split(" ");
                    switch (parts[0])
                    {
                        case "snd":
                            var sndVal = char.IsLower(parts[1][0]) ? registersOne[parts[1][0]] : long.Parse(parts[1]);
                            queueZero.Enqueue(sndVal);
                            sentCount++;
                            break;
                        case "set":
                            var setVal = char.IsLower(parts[2][0]) ? registersOne[parts[2][0]] : long.Parse(parts[2]);
                            if (registersOne.ContainsKey(parts[1][0])) registersOne[parts[1][0]] = setVal;
                            else registersOne.Add(parts[1][0], setVal);
                            break;
                        case "add":
                            var addVal = char.IsLower(parts[2][0]) ? registersOne[parts[2][0]] : long.Parse(parts[2]);
                            if (registersOne.ContainsKey(parts[1][0])) registersOne[parts[1][0]] += addVal;
                            else registersOne.Add(parts[1][0], addVal);
                            break;
                        case "mul":
                            var mulVal = char.IsLower(parts[2][0]) ? registersOne[parts[2][0]] : long.Parse(parts[2]);
                            if (registersOne.ContainsKey(parts[1][0])) registersOne[parts[1][0]] *= mulVal;
                            else registersOne.Add(parts[1][0], 0);
                            break;
                        case "mod":
                            var modVal = char.IsLower(parts[2][0]) ? registersOne[parts[2][0]] : long.Parse(parts[2]);
                            if (registersOne.ContainsKey(parts[1][0])) registersOne[parts[1][0]] %= modVal;
                            else registersOne.Add(parts[1][0], 0);
                            break;
                        case "rcv":
                            if (queueOne.Count == 0) runningZero = true;
                            else registersOne[parts[1][0]] = queueOne.Dequeue();
                            break;
                        case "jgz":
                            var jgzVal1 = char.IsLower(parts[1][0]) ? registersOne[parts[1][0]] : long.Parse(parts[1]);
                            var jgzVal2 = char.IsLower(parts[2][0]) ? registersOne[parts[2][0]] : long.Parse(parts[2]);
                            if (jgzVal1 > 0) indexOne += jgzVal2 - 1;
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            break;
                    }

                    if (!runningZero)
                    {
                        indexOne++;
                        change = 0;
                    }
                    else change++;
                }
            }
            Console.WriteLine("Sent count = " + sentCount);
        }
    }
}
