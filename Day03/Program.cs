using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Day03
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
            var data = int.Parse(input);
            var i = 1;
            while (Math.Pow(i, 2) < data)
            {
                i++;
            }

            var solution = i - 1 - (Math.Pow(i, 2) - data);
            Console.WriteLine("Answer = " + solution);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var goal = int.Parse(input);
            //Web access code from here https://stackoverflow.com/a/2471245
            var client = new WebClient();
            var stream = client.OpenRead("https://oeis.org/A141481/b141481.txt");
            var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            var data = content.Split('\n').Where(x => x != "" && char.IsDigit(x[0])).ToList();
            foreach (var parts in data.Select(s => s.Split(" ").Select(int.Parse).ToList()).Where(parts => parts[1] > goal))
            {
                Console.WriteLine("Solution is " + parts[1]);
                break;
            }
        }
    }
}
