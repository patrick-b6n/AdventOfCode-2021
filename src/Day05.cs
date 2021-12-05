using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021;

[TestClass]
public class Day05
{
    [TestClass]
    public class Part1
    {
        [TestMethod]
        public void HydrothermalVenture()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day05.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(4728, result);
        }

        private static int Solve(string input)
        {
            var pattern = new Regex("(?<x1>[0-9]+),(?<y1>[0-9]+) -> (?<x2>[0-9]+),(?<y2>[0-9]+)");
            var lines = input.Trim().Split("\n").Select(l => l.Trim()).ToList();

            var map = new int[1000, 1000];

            foreach (var line in lines)
            {
                var matchCollection = pattern.Match(line);
                var x1 = int.Parse(matchCollection.Groups["x1"].Value);
                var y1 = int.Parse(matchCollection.Groups["y1"].Value);
                var x2 = int.Parse(matchCollection.Groups["x2"].Value);
                var y2 = int.Parse(matchCollection.Groups["y2"].Value);

                var changeX = Math.Sign(x2 - x1);
                var changeY = Math.Sign(y2 - y1);

                if (changeY == 0)
                {
                    for (var x = x1; x != x2 + changeX; x += changeX)
                    {
                        map[x, y1] += 1;
                    }
                }
                else if (changeX == 0)
                {
                    for (var y = y1; y != y2 + changeY; y += changeY)
                    {
                        map[x1, y] += 1;
                    }
                }
            }

            return map.Flatten().Count(n => n > 1);
        }
    }

    [TestClass]
    public class Part2
    {
        [TestMethod]
        public void HydrothermalVenture()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day05.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(17717, result);
        }

        private static int Solve(string input)
        {
            var pattern = new Regex("(?<x1>[0-9]+),(?<y1>[0-9]+) -> (?<x2>[0-9]+),(?<y2>[0-9]+)");
            var lines = input.Trim().Split("\n").Select(l => l.Trim()).ToList();

            var map = new int[1000, 1000];
            var points = new List<Point>();

            foreach (var line in lines)
            {
                var matchCollection = pattern.Match(line);
                var x1 = int.Parse(matchCollection.Groups["x1"].Value);
                var y1 = int.Parse(matchCollection.Groups["y1"].Value);
                var x2 = int.Parse(matchCollection.Groups["x2"].Value);
                var y2 = int.Parse(matchCollection.Groups["y2"].Value);

                var changeX = Math.Sign(x2 - x1);
                var changeY = Math.Sign(y2 - y1);

                if (changeY == 0)
                {
                    for (var x = x1; x != x2 + changeX; x += changeX)
                    {
                        map[x, y1] += 1;
                        points.Add(new Point(x, y1));
                    }
                }
                else if (changeX == 0)
                {
                    for (var y = y1; y != y2 + changeY; y += changeY)
                    {
                        map[x1, y] += 1;
                        points.Add(new Point(x1, y));
                    }
                }
                else
                {
                    int x, y;
                    for (x = x1, y = y1; x != x2 + changeX && y != y2 + changeY; x += changeX, y += changeY)
                    {
                        map[x, y] += 1;
                        points.Add(new Point(x, y));
                    }
                }
            }

            return map.Flatten().Count(n => n > 1);
        }
    }

    private readonly record struct Point(int X, int Y);
}