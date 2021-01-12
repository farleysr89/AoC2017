using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
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
            var data = input.Split('\n').Where(s => s != "").OrderBy(s => s.Length).ToList();
            var nodes = new List<Node>();
            var tmpData = new List<string>(data);
            foreach (var s in tmpData.Where(s => !s.Contains("->")))
            {
                nodes.Add(new Node { Name = s.Split(" ")[0] });
                data.Remove(s);
            }
            tmpData = new List<string>(data);
            while (data.Count > 0)
            {
                foreach (var s in tmpData)
                {
                    var parts = s.Split(" -> ");
                    var children = parts[1].Split(", ");
                    if (children.Any(c => nodes.All(n => n.Name != c))) continue;
                    nodes.Add(new Node { Name = parts[0].Split(" ")[0], Children = nodes.Where(n => children.Contains(n.Name)).ToList() });
                    foreach (var c in nodes.Where(n => children.Contains(n.Name)))
                    {
                        c.Parent = nodes.First(x => x.Name == parts[0].Split(" ")[0]);
                    }
                    data.Remove(s);
                }
                tmpData = new List<string>(data);
            }
            Console.WriteLine("Base node = " + nodes.First(n => n.Parent == null).Name);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }

    internal class Node
    {
        internal string Name;
        internal Node Parent;
        internal List<Node> Children;
    }
}
