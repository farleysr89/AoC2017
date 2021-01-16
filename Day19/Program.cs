using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day19
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
            var map = new List<List<char>>();
            var index = 0;
            foreach (var s in data)
            {
                map.Add(new List<char>());
                foreach (var c in s)
                {
                    map[index].Add(c);
                }

                index++;
            }

            var y = 0;
            var x = map[0].IndexOf('|');
            var traveledString = "";
            var dir = 'd';
            while (true)
            {
                if (!CheckMove(x, y, map)) break;
                var nextChar = map[y][x];
                if (nextChar == ' ') break;
                if (char.IsLetter(nextChar)) traveledString += nextChar;
                if (nextChar == '+')
                {
                    switch (dir)
                    {
                        case 'l':
                        case 'r':
                            {
                                if (CheckMove(x, y - 1, map) && CheckDirMove(x, y - 1, map, dir))
                                {
                                    y--;
                                    dir = 'u';
                                }
                                else if (CheckMove(x, y + 1, map) && CheckDirMove(x, y + 1, map, dir))
                                {
                                    y++;
                                    dir = 'd';
                                }

                                break;
                            }
                        case 'u':
                        case 'd':
                            {
                                if (CheckMove(x - 1, y, map) && CheckDirMove(x - 1, y, map, dir))
                                {
                                    x--;
                                    dir = 'l';
                                }
                                else if (CheckMove(x + 1, y, map) && CheckDirMove(x + 1, y, map, dir))
                                {
                                    x++;
                                    dir = 'r';
                                }

                                break;
                            }
                    }
                }
                else
                    switch (dir)
                    {
                        case 'u':
                            y--;
                            break;
                        case 'd':
                            y++;
                            break;
                        case 'l':
                            x--;
                            break;
                        case 'r':
                            x++;
                            break;
                        default:
                            break;
                    }
            }
            Console.WriteLine("Traveled string = " + traveledString);
        }

        private static bool CheckMove(int x, int y, List<List<char>> map)
        {
            return y >= 0 && x >= 0 && x <= map[0].Count - 1 && y <= map.Count - 1;
        }
        private static bool CheckDirMove(int x, int y, List<List<char>> map, char dir)
        {
            switch (dir)
            {
                case 'r':
                case 'l':
                    return map[y][x] == '|';
                case 'u':
                case 'd':
                    return map[y][x] == '-';
                default:
                    Console.WriteLine("Something Broke!");
                    return false;
            }
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
