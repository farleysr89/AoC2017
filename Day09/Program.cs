using System;
using System.IO;
using System.Linq;

namespace Day09
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
            var stream = data[0];
            var score = 0;
            var groupCount = 0;
            var ignore = false;
            for (var i = 0; i < stream.Length; i++)
            {
                var c = stream[i];
                if (!ignore)
                {
                    if (c == '{')
                    {
                        groupCount++;
                        score += groupCount;
                    }
                    else if (c == '}')
                    {
                        groupCount--;
                    }
                    else if (c == '<')
                    {
                        ignore = true;
                    }
                    else if (c == '!')
                    {
                        i++;
                    }
                }
                else if (c == '>')
                {
                    ignore = false;
                }
                else if (c == '!')
                {
                    i++;
                }
            }
            Console.WriteLine("Total score = " + score);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
