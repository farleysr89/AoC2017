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
                    switch (c)
                    {
                        case '{':
                            groupCount++;
                            score += groupCount;
                            break;
                        case '}':
                            groupCount--;
                            break;
                        case '<':
                            ignore = true;
                            break;
                        case '!':
                            i++;
                            break;
                    }
                }
                else switch (c)
                    {
                        case '>':
                            ignore = false;
                            break;
                        case '!':
                            i++;
                            break;
                    }
            }
            Console.WriteLine("Total score = " + score);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var stream = data[0];
            var ignore = false;
            var garbageCount = 0;
            for (var i = 0; i < stream.Length; i++)
            {
                var c = stream[i];
                if (!ignore)
                {
                    switch (c)
                    {
                        case '<':
                            ignore = true;
                            break;
                        case '!':
                            i++;
                            break;
                    }
                }
                else switch (c)
                    {
                        case '>':
                            ignore = false;
                            break;
                        case '!':
                            i++;
                            break;
                        default:
                            garbageCount++;
                            break;
                    }
            }
            Console.WriteLine("Total garbage = " + garbageCount);
        }
    }
}
