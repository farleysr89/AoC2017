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
            var data = input.Split('\n').Where(s => s != "").OrderBy(s => s.Length).ToList();
            var nodes = new List<Node>();
            var tmpData = new List<string>(data);
            foreach (var s in tmpData.Where(s => !s.Contains("->")))
            {
                nodes.Add(new Node { Name = s.Split(" ")[0], Weight = int.Parse(s.Split(" ")[1].Replace("(", "").Replace(")", "")) });
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
                    nodes.Add(new Node { Name = parts[0].Split(" ")[0], Children = nodes.Where(n => children.Contains(n.Name)).ToList(), Weight = int.Parse(parts[0].Split(" ")[1].Replace("(", "").Replace(")", "")) });
                    foreach (var c in nodes.Where(n => children.Contains(n.Name)))
                    {
                        c.Parent = nodes.First(x => x.Name == parts[0].Split(" ")[0]);
                    }
                    data.Remove(s);
                }
                tmpData = new List<string>(data);
            }

            var problemNodes = nodes.Where(n =>
                n.Children.Any(c => c.NestedWeight() != n.Children.Max(cc => cc.NestedWeight())));
            var node = problemNodes.First();
            //Console.WriteLine(c.Name + " " + string.Join(",", c.Children.Select(x => x.Name + ":" + x.NestedWeight())));
            var p = node.Children.GroupBy(c => c.NestedWeight()).First(g => g.Count() == 1).First();
            var g = node.Children.GroupBy(c => c.NestedWeight()).First(g => g.Count() > 1).First().NestedWeight();
            var t = Calculate(g, p);
            Console.WriteLine("Final weight of changed node = " + t);

        }

        private static int Calculate(int target, Node n)
        {
            return target - n.Children.Sum(c => c.NestedWeight());
        }
    }

    internal class Node
    {
        internal string Name;
        internal Node Parent;
        internal List<Node> Children = new List<Node>();
        internal int Weight;
        internal int NestedWeight()
        {
            return Weight + Children.Select(c => c.NestedWeight()).Sum();
        }
    }
}
