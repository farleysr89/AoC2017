using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day25
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
            var startPos = data[0].Split(" ")[3][..^1];
            var diagnosticTarget = int.Parse(data[1].Split(" ")[5]);
            var states = new List<State>();
            var positions = new Dictionary<int, bool> { { 0, false } };
            for (var i = 3; i <= data.Count - 3;)
            {
                var parts = data[i].Split(" ");
                var state = new State { Id = parts[2][..^1] };
                i += 2;
                parts = data[i].Split(" ");
                var rule = new Rule { Output = int.Parse(parts[8][..^1]) };
                i++;
                parts = data[i].Split(" ");
                rule.Move = parts[10] == "right." ? 1 : -1;
                i++;
                parts = data[i].Split(" ");
                rule.NextState = parts[8][..^1];
                state.ZeroRule = rule;
                i += 2;
                parts = data[i].Split(" ");
                rule = new Rule { Output = int.Parse(parts[8][..^1]) };
                i++;
                parts = data[i].Split(" ");
                rule.Move = parts[10] == "right." ? 1 : -1;
                i++;
                parts = data[i].Split(" ");
                rule.NextState = parts[8][..^1];
                state.OneRule = rule;
                i += 2;
                states.Add(state);
            }

            var nextState = states.First(s => s.Id == startPos);
            var curIndex = 0;
            for (var i = 0; i < diagnosticTarget; i++)
            {
                var curPos = positions[curIndex];
                var rule = curPos ? nextState.OneRule : nextState.ZeroRule;
                positions[curIndex] = rule.Output == 1;
                curIndex += rule.Move;
                if (!positions.ContainsKey(curIndex)) positions.Add(curIndex, false);
                nextState = states.First(s => s.Id == rule.NextState);
            }
            Console.WriteLine("Diagnostic Checksum = " + positions.Count(p => p.Value));
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }

    internal class State
    {
        internal string Id;
        internal Rule ZeroRule;
        internal Rule OneRule;
    }

    internal class Rule
    {
        internal int Output;
        internal int Move;
        internal string NextState;
    }
}
