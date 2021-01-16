using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day20
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
            var particles = new List<Particle>();
            var index = 0;
            foreach (var s in data.Where(s => s != ""))
            {
                var parts = s.Split(", ");
                var pos = parts[0][(parts[0].IndexOf('<') + 1)..^1].Split(",").Select(int.Parse).ToList();
                var vel = parts[1][(parts[1].IndexOf('<') + 1)..^1].Split(",").Select(int.Parse).ToList();
                var acc = parts[2][(parts[2].IndexOf('<') + 1)..^1].Split(",").Select(int.Parse).ToList();
                particles.Add(new Particle
                {
                    Id = index,
                    Position = (pos[0], pos[1], pos[2]),
                    Velocity = (vel[0], vel[1], vel[2]),
                    Acceleration = (acc[0], acc[1], acc[2])
                });
                index++;
            }
            particles = particles
            .OrderBy(p => Math.Abs(p.Acceleration.Item1) + Math.Abs(p.Acceleration.Item2) + Math.Abs(p.Acceleration.Item3))
            .ThenBy(p => Math.Abs(p.Velocity.Item1) + Math.Abs(p.Velocity.Item2) + Math.Abs(p.Velocity.Item3))
            .ThenBy(p => Math.Abs(p.Position.Item1) + Math.Abs(p.Position.Item2) + Math.Abs(p.Position.Item3)).ToList(); ;
            Console.WriteLine("Closest particle to origin is " + particles.First().Id);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }

    internal class Particle
    {
        internal int Id;
        internal (int, int, int) Position;
        internal (int, int, int) Velocity;
        internal (int, int, int) Acceleration;
    }
}
