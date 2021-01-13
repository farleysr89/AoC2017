using System;
using System.IO;
using System.Linq;

namespace Day11
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
            //Big help from here: https://www.redblobgames.com/grids/hexagons/
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var moves = data[0].Split(",");
            int x = 0, y = 0, z = 0;
            foreach (var m in moves)
            {
                switch (m)
                {
                    case "nw":
                        x--;
                        y++;
                        break;
                    case "n":
                        y++;
                        z--;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }
            Console.WriteLine("Distance to child is " + ((Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2));
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
