using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day24
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
            var maxStrength = int.MinValue;
            var components = data.Where(s => s != "")
                .Select(s => s.Split('/')
                .Select(int.Parse).ToList())
                .Select(parts => new Component { PortA = parts[0], PortB = parts[1] }).ToList();

            foreach (var comp in components.Where(c => c.PortA == 0 || c.PortB == 0))
            {
                var tmpComps = new List<Component>(components);
                tmpComps.Remove(comp);
                if (comp.PortA == 0)
                    maxStrength = Math.Max(maxStrength, BuildBridge(comp.Strength, comp.PortB, tmpComps));
                if (comp.PortB == 0)
                    maxStrength = Math.Max(maxStrength, BuildBridge(comp.Strength, comp.PortA, tmpComps));
            }
            Console.WriteLine("Max strength bridge = " + maxStrength);
        }

        private static int BuildBridge(int strength, int lastPort, List<Component> components)
        {
            if (!components.Any(c => c.PortA == lastPort || c.PortB == lastPort)) return strength;
            var maxStrength = int.MinValue;
            foreach (var comp in components.Where(c => c.PortA == lastPort || c.PortB == lastPort))
            {
                var tmpComps = new List<Component>(components);
                tmpComps.Remove(comp);
                if (comp.PortA == lastPort)
                    maxStrength = Math.Max(maxStrength, BuildBridge(strength + comp.Strength, comp.PortB, tmpComps));
                if (comp.PortB == lastPort)
                    maxStrength = Math.Max(maxStrength, BuildBridge(strength + comp.Strength, comp.PortA, tmpComps));
            }

            return maxStrength;
        }

        private static List<Bridge> BuildBridges(int strength, int length, int lastPort, List<Component> components)
        {
            if (!components.Any(c => c.PortA == lastPort || c.PortB == lastPort)) return new List<Bridge>
            {
                new Bridge
                {
                    Length = length,
                    Strength = strength
                }
            };
            var bridges = new List<Bridge>();
            foreach (var comp in components.Where(c => c.PortA == lastPort || c.PortB == lastPort))
            {
                var tmpComps = new List<Component>(components);
                tmpComps.Remove(comp);
                if (comp.PortA == lastPort)
                    bridges.AddRange(BuildBridges(strength + comp.Strength, length + 1, comp.PortB, tmpComps));
                if (comp.PortB == lastPort)
                    bridges.AddRange(BuildBridges(strength + comp.Strength, length + 1, comp.PortA, tmpComps));
            }

            return bridges;
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var components = data.Where(s => s != "")
                .Select(s => s.Split('/')
                    .Select(int.Parse).ToList())
                .Select(parts => new Component { PortA = parts[0], PortB = parts[1] }).ToList();
            var bridges = new List<Bridge>();
            foreach (var comp in components.Where(c => c.PortA == 0 || c.PortB == 0))
            {
                var tmpComps = new List<Component>(components);
                tmpComps.Remove(comp);
                if (comp.PortA == 0)
                    bridges.AddRange(BuildBridges(comp.Strength, 1, comp.PortB, tmpComps));
                if (comp.PortB == 0)
                    bridges.AddRange(BuildBridges(comp.Strength, 1, comp.PortA, tmpComps));
            }

            bridges = bridges.OrderByDescending(b => b.Length).ThenByDescending(b => b.Strength).ToList();
            Console.WriteLine("Max strength of longest bridge = " + bridges.First().Strength);
        }
    }

    internal class Component
    {
        internal int PortA;
        internal int PortB;
        internal int Strength => PortA + PortB;
    }

    internal class Bridge
    {
        internal int Strength;
        internal int Length;
    }
}
