using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day14
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
            var hash = input.Split('\n')[0];
            var count = 0;
            for (var i = 0; i < 128; i++)
            {
                count += KnotHash(hash + "-" + i);
            }

            Console.WriteLine("Count = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var hash = input.Split('\n')[0];
            var bins = new List<string>();
            var count = 1;
            for (var i = 0; i < 128; i++)
            {
                bins.Add(KnotHashString(hash + "-" + i));
            }

            var data = new List<List<int>>();
            var row = 0;
            foreach (var s in bins)
            {
                data.Add(new List<int>());
                foreach (var c in s)
                {
                    data[row].Add(c == '1' ? 0 : -1);
                }
                row++;
            }

            for (var y = 0; y < 128; y++)
            {
                for (var x = 0; x < 128; x++)
                {
                    if (data[y][x] != 0) continue;
                    data = ProcessGroup(x, y, data, count);
                    count++;
                }
            }

            Console.WriteLine("Count = " + (count - 1));
        }

        private static int KnotHash(string s)
        {
            var lengths = s.Select(c => (int)c);
            lengths = lengths.Append(17);
            lengths = lengths.Append(31);
            lengths = lengths.Append(73);
            lengths = lengths.Append(47);
            lengths = lengths.Append(23);
            var skip = 0;
            var currPosition = 0;
            var nums = new List<int>();
            for (var i = 0; i <= 255; i++)
            {
                nums.Add(i);
            }

            for (var j = 1; j <= 64; j++)
            {
                foreach (var l in lengths)
                {
                    var tmpArray = new int[l];
                    for (var i = 0; i < l; i++)
                    {
                        tmpArray[i] = nums[(currPosition + i) % nums.Count];
                    }

                    tmpArray = tmpArray.Reverse().ToArray();
                    for (var i = 0; i < l; i++)
                    {
                        nums[(currPosition + i) % nums.Count] = tmpArray[i];
                    }

                    currPosition += l + skip;
                    currPosition %= nums.Count;
                    skip++;
                }
            }

            var results = new List<string>();
            for (var i = 0; i < 16; i++)
            {
                var result = 0;
                for (var j = 0; j < 16; j++)
                {
                    result ^= nums[(i * 16) + j];
                }
                results.Add(result.ToString("X").PadLeft(2, '0'));
            }

            var solution = string.Join("", results);
            var sb = new StringBuilder();
            foreach (var c in solution.ToCharArray())
            {
                sb.Append(Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2));
            }
            return sb.ToString().Count(b => b == '1');
        }

        private static string KnotHashString(string s)
        {
            var lengths = s.Select(c => (int)c);
            lengths = lengths.Append(17);
            lengths = lengths.Append(31);
            lengths = lengths.Append(73);
            lengths = lengths.Append(47);
            lengths = lengths.Append(23);
            var skip = 0;
            var currPosition = 0;
            var nums = new List<int>();
            for (var i = 0; i <= 255; i++)
            {
                nums.Add(i);
            }

            for (var j = 1; j <= 64; j++)
            {
                foreach (var l in lengths)
                {
                    var tmpArray = new int[l];
                    for (var i = 0; i < l; i++)
                    {
                        tmpArray[i] = nums[(currPosition + i) % nums.Count];
                    }

                    tmpArray = tmpArray.Reverse().ToArray();
                    for (var i = 0; i < l; i++)
                    {
                        nums[(currPosition + i) % nums.Count] = tmpArray[i];
                    }

                    currPosition += l + skip;
                    currPosition %= nums.Count;
                    skip++;
                }
            }

            var results = new List<string>();
            for (var i = 0; i < 16; i++)
            {
                var result = 0;
                for (var j = 0; j < 16; j++)
                {
                    result ^= nums[(i * 16) + j];
                }
                results.Add(result.ToString("X").PadLeft(2, '0'));
            }

            var solution = string.Join("", results);
            var sb = new StringBuilder();
            foreach (var c in solution.ToCharArray())
            {
                sb.Append(Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'));
            }
            return sb.ToString();
        }

        private static List<List<int>> ProcessGroup(int x, int y, List<List<int>> data, int count)
        {
            data[y][x] = count;
            if (CheckMove(x - 1, y, data))
                data = ProcessGroup(x - 1, y, data, count);
            if (CheckMove(x + 1, y, data))
                data = ProcessGroup(x + 1, y, data, count);
            if (CheckMove(x, y - 1, data))
                data = ProcessGroup(x, y - 1, data, count);
            if (CheckMove(x, y + 1, data))
                data = ProcessGroup(x, y + 1, data, count);
            return data;
        }

        private static bool CheckMove(int x, int y, List<List<int>> data)
        {
            return x >= 0 && y >= 0 && x < data.Count && y < data.Count && data[y][x] == 0;
        }
    }
}
