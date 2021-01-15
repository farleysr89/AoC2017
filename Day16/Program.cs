using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Day16
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
            var data = input.Split(',').ToList();
            var programs = new StringBuilder("abcdefghijklmnop");
            foreach (var s in data)
            {
                switch (s[0])
                {
                    case 's':
                        var moves = int.Parse(s[1..]);
                        programs = new StringBuilder(ShiftRight(programs.ToString(), moves));
                        break;
                    case 'x':
                        var sx = s[1..];
                        var sxParts = sx.Split("/").Select(int.Parse).ToList();
                        var tmpA = programs[sxParts[0]];
                        var tmpB = programs[sxParts[1]];
                        programs[sxParts[0]] = tmpB;
                        programs[sxParts[1]] = tmpA;
                        break;
                    case 'p':
                        var sp = s[1..];
                        var spParts = sp.Split("/").ToList();
                        var tmpC = spParts[0][0];
                        var tmpD = spParts[1][0];
                        var tmpE = programs.ToString().IndexOf(tmpC);
                        var tmpF = programs.ToString().IndexOf(tmpD);
                        programs[tmpE] = tmpD;
                        programs[tmpF] = tmpC;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }
            Console.WriteLine("Final order = " + programs);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }

        public static string ShiftRight(string s, int count)
        {
            for (var i = 0; i < count; i++)
            {
                s = s[^1] + s[0..^1];
            }

            return s;
        }
    }
}
