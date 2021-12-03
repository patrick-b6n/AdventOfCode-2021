using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021;

[TestClass]
public class Day01
{
    [TestClass]
    public class Part1
    {
        [TestMethod]
        public void SonarSweep()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day01.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(1529, result);
        }

        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n");

            var count = 0;
            for (var i = 1; i < lines.Length; i++)
            {
                var previousDepth = int.Parse(lines[i - 1]);
                var currentDepth = int.Parse(lines[i]);

                if (previousDepth < currentDepth)
                {
                    count++;
                }
            }

            return count;
        }
    }

    [TestClass]
    public class Part2
    {
        [TestMethod]
        public void SonarSweep()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day01.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(1567, result);
        }

        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n");

            var count = 0;
            for (var i = 3; i < lines.Length; i++)
            {
                var previousDepth = int.Parse(lines[i - 3]);
                var currentDepth = int.Parse(lines[i]);

                if (previousDepth < currentDepth)
                {
                    count++;
                }
            }

            return count;
        }
    }
}