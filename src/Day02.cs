using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021;

[TestClass]
public class Day02
{
    [TestClass]
    public class Part1
    {
        [TestMethod]
        public void Dive()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day02.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(1692075, result);
        }

        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n");

            var depth = 0;
            var horizontal = 0;

            foreach (var line in lines)
            {
                var instruction = line.Split(" ");

                switch (instruction[0])
                {
                    case "forward":
                        horizontal += int.Parse(instruction[1]);
                        break;
                    case "up":
                        depth -= int.Parse(instruction[1]);
                        break;
                    case "down":
                        depth += int.Parse(instruction[1]);
                        break;
                }
            }

            return depth * horizontal;
        }
    }

    [TestClass]
    public class Part2
    {
        [TestMethod]
        public void Dive()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day02.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(1749524700, result);
        }

        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n");

            var aim = 0;
            var depth = 0;
            var horizontal = 0;

            foreach (var line in lines)
            {
                var instruction = line.Split(" ");

                switch (instruction[0])
                {
                    case "forward":
                        horizontal += int.Parse(instruction[1]);
                        depth += aim * int.Parse(instruction[1]);
                        break;
                    case "up":
                        aim -= int.Parse(instruction[1]);
                        break;
                    case "down":
                        aim += int.Parse(instruction[1]);
                        break;
                }
            }

            return depth * horizontal;
        }
    }
}