using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day21
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
            var start = ".#./..#/###";
            var rules =
                data.Where(s => s != "").
                    Select(s => s.Split(" => ")).
                    Select(parts => new Rule { Input = parts[0], Output = parts[1] }).ToList();
            rules.ForEach(r => r.GetVariations());
            var squares = new List<string> { start };
            for (var i = 0; i < 5; i++)
            {
                var newSquares = new List<string>();
                var parts = squares[0].Split("/");
                var val = parts[0].Length * Math.Sqrt(squares.Count);
                if (val % 2 == 0 && parts[0].Length % 3 == 0)
                {
                    for (var x = 0; x < squares.Count; x += 4)
                    {
                        var tmpSquares = Get2DSquaresFrom3D(squares.GetRange(x, 4));
                        foreach (var tmpSquare in tmpSquares)
                        {
                            newSquares.Add(rules.First(r => r.Inputs.Contains(tmpSquare)).Output);
                        }
                    }
                }
                else
                {
                    foreach (var square in squares)
                    {

                        if (square.Length == 11)
                        {
                            newSquares.Add(rules.First(r => r.Inputs.Contains(square)).Output);
                        }
                        else if (square.Length == 19)
                        {
                            var tmpSquares = Get2DSquares(square);
                            foreach (var tmpSquare in tmpSquares)
                            {
                                newSquares.Add(rules.First(r => r.Inputs.Contains(tmpSquare)).Output);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something Broke!");
                        }
                    }
                }

                squares = new List<string>(newSquares);
            }

            var count = 0;
            foreach (var s in squares)
            {
                count += s.Count(c => c == '#');
            }

            Console.WriteLine("Pixel count = " + count);
        }

        private static void SolvePart2()
        {
            var input = File.ReadAllText("Input.txt");
            var data = input.Split('\n').ToList();
            var start = ".#./..#/###";
            var rules =
                data.Where(s => s != "").
                    Select(s => s.Split(" => ")).
                    Select(parts => new Rule { Input = parts[0], Output = parts[1] }).ToList();
            rules.ForEach(r => r.GetVariations());
            var squares = new List<string> { start };
            for (var i = 0; i < 18; i++)
            {
                var newSquares = new List<string>();
                var parts = squares[0].Split("/");
                var val = parts[0].Length * Math.Sqrt(squares.Count);
                if (val % 2 == 0 && parts[0].Length % 3 == 0)
                {
                    for (var x = 0; x < squares.Count; x += 4)
                    {
                        var tmpSquares = Get2DSquaresFrom3D(squares.GetRange(x, 4));
                        foreach (var tmpSquare in tmpSquares)
                        {
                            newSquares.Add(rules.First(r => r.Inputs.Contains(tmpSquare)).Output);
                        }
                    }
                }
                else
                {
                    foreach (var square in squares)
                    {

                        if (square.Length == 11)
                        {
                            newSquares.Add(rules.First(r => r.Inputs.Contains(square)).Output);
                        }
                        else if (square.Length == 19)
                        {
                            var tmpSquares = Get2DSquares(square);
                            foreach (var tmpSquare in tmpSquares)
                            {
                                newSquares.Add(rules.First(r => r.Inputs.Contains(tmpSquare)).Output);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something Broke!");
                        }
                    }
                }

                squares = new List<string>(newSquares);
            }

            var count = 0;
            foreach (var s in squares)
            {
                count += s.Count(c => c == '#');
            }

            Console.WriteLine("Pixel count = " + count);
        }

        internal static List<string> Get2DSquares(string s)
        {
            var squares = new List<string>
            {
                s[0].ToString() + s[1] + "/" + s[5] + s[6],
                s[2].ToString() + s[3] + "/" + s[7] + s[8],
                s[10].ToString() + s[11] + "/" + s[15] + s[16],
                s[12].ToString() + s[13] + "/" + s[17] + s[18]
            };
            return squares;
        }
        internal static List<string> Get2DSquaresFrom3D(List<string> s)
        {
            var squares = new List<string>
            {
                s[0][0].ToString() + s[0][1] + "/" + s[0][4] + s[0][5],
                s[0][2].ToString() + s[1][0] + "/" + s[0][6] + s[1][4],
                s[1][1].ToString() + s[1][2] + "/" + s[1][5] + s[1][6],
                s[0][8].ToString() + s[0][9] + "/" + s[2][0] + s[2][1],
                s[0][10].ToString() + s[1][8] + "/" + s[2][2] + s[3][0],
                s[1][9].ToString() + s[1][10] + "/" + s[3][1] + s[3][2],
                s[2][4].ToString() + s[2][5] + "/" + s[2][8] + s[2][9],
                s[2][6].ToString() + s[3][4] + "/" + s[2][10] + s[3][8],
                s[3][5].ToString() + s[3][6] + "/" + s[3][9] + s[3][10]
            };
            return squares;
        }
    }

    internal class Rule
    {
        internal string Input;
        internal List<string> Inputs = new List<string>();
        internal string Output;

        internal void GetVariations()
        {
            string newS;
            switch (Input.Length)
            {
                case 5:
                    Inputs.Add(Input);
                    newS = Transpose2D(Input);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip2D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Transpose2D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip2D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Transpose2D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip2D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Transpose2D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip2D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    break;
                case 11:
                    Inputs.Add(Input);
                    newS = Transpose3D(Input);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip3D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Transpose3D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip3D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Transpose3D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip3D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Transpose3D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    newS = Flip3D(newS);
                    if (!Inputs.Contains(newS)) Inputs.Add(newS);
                    break;
                default:
                    Console.WriteLine("Something Broke!");
                    break;
            }
        }

        internal string Transpose2D(string s)
        {
            return s[0].ToString() + s[3] + "/" + s[1] + s[4];
        }

        internal string Transpose3D(string s)
        {
            return s[0].ToString() + s[4] + s[8] + "/" + s[1] + s[5] + s[9] + "/" + s[2] + s[6] + s[10];
        }

        internal string Flip2D(string s)
        {
            return s[3].ToString() + s[4] + "/" + s[0] + s[1];
        }

        internal string Flip3D(string s)
        {
            var parts = s.Split("/");
            return parts[2] + "/" + parts[1] + "/" + parts[0];
        }
    }
}
