using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day22
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
            var virusX = data.Count / 2 - 1;
            var virusY = virusX;
            var x = 0;
            var y = 0;
            var dir = 'u';
            var nodes = new List<Node>();
            foreach (var s in data.Where(s => s != ""))
            {
                x = 0;
                foreach (var c in s)
                {
                    nodes.Add(new Node { X = x, Y = y, Infected = c == '#' ? State.Infected : State.Clean });
                    x++;
                }

                y++;
            }

            var count = 0;
            var infectionCount = 0;
            while (count < 10000)
            {
                count++;
                var node = nodes.First(n => n.X == virusX && n.Y == virusY);
                if (node.Infected == State.Infected)
                {
                    switch (dir)
                    {
                        case 'u':
                            dir = 'r';
                            break;
                        case 'r':
                            dir = 'd';
                            break;
                        case 'd':
                            dir = 'l';
                            break;
                        case 'l':
                            dir = 'u';
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            break;
                    }
                }
                else
                {
                    infectionCount++;
                    switch (dir)
                    {
                        case 'u':
                            dir = 'l';
                            break;
                        case 'r':
                            dir = 'u';
                            break;
                        case 'd':
                            dir = 'r';
                            break;
                        case 'l':
                            dir = 'd';
                            break;
                        default:
                            Console.WriteLine("Something Broke!");
                            break;
                    }
                }
                switch (dir)
                {
                    case 'u':
                        virusY--;
                        break;
                    case 'r':
                        virusX++;
                        break;
                    case 'd':
                        virusY++;
                        break;
                    case 'l':
                        virusX--;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }

                node.Infected = node.Infected == State.Infected ? State.Clean : State.Infected;
                if (!nodes.Any(n => n.X == virusX && n.Y == virusY)) nodes.Add(new Node { X = virusX, Y = virusY, Infected = State.Clean });
            }
            Console.WriteLine("New infection count = " + infectionCount);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var virusX = data.Count / 2 - 1;
            var virusY = virusX;
            var x = 0;
            var y = 0;
            var dir = 'u';
            var nodes = new Dictionary<(int, int), State>();
            foreach (var s in data.Where(s => s != ""))
            {
                x = 0;
                foreach (var c in s)
                {
                    nodes.Add((x, y), c == '#' ? State.Infected : State.Clean);
                    x++;
                }

                y++;
            }

            var count = 0;
            var infectionCount = 0;
            while (count < 10000000)
            {
                count++;
                var node = nodes[(virusX, virusY)];
                switch (node)
                {
                    case State.Infected:
                        switch (dir)
                        {
                            case 'u':
                                dir = 'r';
                                break;
                            case 'r':
                                dir = 'd';
                                break;
                            case 'd':
                                dir = 'l';
                                break;
                            case 'l':
                                dir = 'u';
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }

                        nodes[(virusX, virusY)] = State.Flagged;
                        break;
                    case State.Clean:
                        switch (dir)
                        {
                            case 'u':
                                dir = 'l';
                                break;
                            case 'r':
                                dir = 'u';
                                break;
                            case 'd':
                                dir = 'r';
                                break;
                            case 'l':
                                dir = 'd';
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }

                        nodes[(virusX, virusY)] = State.Weakened;
                        break;
                    case State.Flagged:
                        switch (dir)
                        {
                            case 'u':
                                dir = 'd';
                                break;
                            case 'r':
                                dir = 'l';
                                break;
                            case 'd':
                                dir = 'u';
                                break;
                            case 'l':
                                dir = 'r';
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }

                        nodes[(virusX, virusY)] = State.Clean;
                        break;
                    case State.Weakened:
                        infectionCount++;
                        nodes[(virusX, virusY)] = State.Infected;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
                switch (dir)
                {
                    case 'u':
                        virusY--;
                        break;
                    case 'r':
                        virusX++;
                        break;
                    case 'd':
                        virusY++;
                        break;
                    case 'l':
                        virusX--;
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
                if (!nodes.ContainsKey((virusX, virusY))) nodes.Add((virusX, virusY), State.Clean);
            }
            Console.WriteLine("New infection count = " + infectionCount);
        }
    }

    internal class Node
    {
        internal int X;
        internal int Y;
        internal State Infected;
    }
    internal enum State
    {
        Clean,
        Weakened,
        Infected,
        Flagged
    }
}
