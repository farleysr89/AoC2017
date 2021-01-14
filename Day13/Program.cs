using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
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
            var gates = new List<Gate>();
            var position = -1;
            foreach (var s in data.Where(s => s != ""))
            {
                var parts = s.Split(": ").Select(int.Parse).ToList();
                gates.Add(new Gate { Index = parts[0], Position = 0, Size = parts[1], Direction = true });
            }
            var severity = 0;
            while (position < gates.Max(g => g.Index))
            {
                position++;
                var gate = gates.FirstOrDefault(g => g.Index == position && g.Position == 0);
                if (gate != null)
                {
                    severity += gate.Index * gate.Size;
                }
                gates.ForEach(g => g.Move());
            }
            Console.WriteLine("Total Severity = " + severity);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var gates = new List<Gate>();
            foreach (var s in data.Where(s => s != ""))
            {
                var parts = s.Split(": ").Select(int.Parse).ToList();
                gates.Add(new Gate { Index = parts[0], Position = 0, Size = parts[1], Direction = true });
            }
            var delay = -1;
            var found = false;
            while (!found)
            {
                delay++;
                found = true;
                foreach (var g in gates)
                {
                    if ((delay + g.Index) % ((g.Size - 1) * 2) == 0)
                    {
                        found = false;
                        break;
                    }
                }
            }
            Console.WriteLine("Delay = " + delay);
        }
    }

    internal class Gate
    {
        internal int Index;
        internal int Position;
        internal int Size;
        internal bool Direction;
        internal void Move()
        {
            if (Direction)
            {
                if (Position == Size - 1)
                {
                    Direction = false;
                    Position--;
                }
                else Position++;
            }
            else
            {
                if (Position == 0)
                {
                    Direction = true;
                    Position++;
                }
                else Position--;
            }
        }
    }
}
