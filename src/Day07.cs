using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021;

[TestClass]
public class Day07
{
    [TestClass]
    public class Part1
    {
        [TestMethod]
        public void TheTreacheryOfWhales()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day07.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(336701, result);
        }

        private static int Solve(string input)
        {
            var positions = input.Trim().Split(",").Select(int.Parse).ToArray();

            var median = positions.Median();
            return positions.Sum(position => Math.Abs(position - median));
        }
    }

    [TestClass]
    public class Part2
    {
        [TestMethod]
        public void TheTreacheryOfWhales()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day07.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(95167302, result);
        }

        private static int Solve(string input)
        {
            var positions = input.Trim().Split(",").Select(int.Parse).ToArray();

            var avg = (int)positions.Average();
            return positions.Sum(position => Math.Abs(position - avg).TriangularNumber());
        }
    }
}