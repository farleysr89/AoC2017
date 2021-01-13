using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day12
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
            var connections = new List<string> { "0" };
            var change = true;
            var tmpData = new List<string>(data);
            while (change)
            {
                change = false;
                foreach (var s in tmpData.Where(s => s != ""))
                {
                    var parts = s.Split(" <-> ");
                    if (connections.Contains(parts[0]))
                    {
                        change = true;
                        var newNums = parts[1].Split(", ");
                        connections.AddRange(newNums.Where(y => !connections.Contains(y)).Select(x => x));
                        data.Remove(s);
                    }
                    else
                    {
                        continue;
                    }
                }
                tmpData = new List<string>(data);
                data = new List<string>(tmpData);
            }

            Console.WriteLine("Solution = " + connections.Count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').Where(s => s != "").ToList();
            var groups = 0;
            while (data.Any())
            {
                groups++;
                var connections = new List<string>();
                connections.Add(data.First().Split(" <-> ")[0]);
                var change = true;
                var tmpData = new List<string>(data);
                while (change)
                {
                    change = false;
                    foreach (var s in tmpData.Where(s => s != ""))
                    {
                        var parts = s.Split(" <-> ");
                        if (connections.Contains(parts[0]))
                        {
                            change = true;
                            var newNums = parts[1].Split(", ");
                            connections.AddRange(newNums.Where(y => !connections.Contains(y)).Select(x => x));
                            data.Remove(s);
                        }
                        else
                        {
                            continue;
                        }
                    }

                    tmpData = new List<string>(data);
                    data = new List<string>(tmpData);
                }
                data = new List<string>(tmpData);
            }

            Console.WriteLine("Solution = " + groups);
        }
    }
}
