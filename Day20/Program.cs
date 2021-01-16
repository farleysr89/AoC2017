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

            var count = 0;
            while (count < 100)
            {
                var tmpParticles = new List<Particle>(particles);
                foreach (var p in tmpParticles)
                {
                    if (particles.Any(part =>
                        part.Id != p.Id && part.Position.Item1 == p.Position.Item1 &&
                        part.Position.Item2 == p.Position.Item2 && part.Position.Item3 == p.Position.Item3))
                    {
                        particles.RemoveAll(part =>
                            part.Position.Item1 == p.Position.Item1 && part.Position.Item2 == p.Position.Item2 &&
                            part.Position.Item3 == p.Position.Item3);
                    }
                }

                if (tmpParticles.Count == particles.Count) count++;
                else count = 0;
                particles.ForEach(p => p.Update());
            }

            Console.WriteLine("Remaining particles = " + particles.Count);
        }
    }

    internal class Particle
    {
        internal int Id;
        internal (int, int, int) Position;
        internal (int, int, int) Velocity;
        internal (int, int, int) Acceleration;

        internal void Update()
        {
            Velocity.Item1 += Acceleration.Item1;
            Velocity.Item2 += Acceleration.Item2;
            Velocity.Item3 += Acceleration.Item3;
            Position.Item1 += Velocity.Item1;
            Position.Item2 += Velocity.Item2;
            Position.Item3 += Velocity.Item3;
        }
    }
}
