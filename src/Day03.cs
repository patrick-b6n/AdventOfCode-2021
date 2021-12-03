using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021;

[TestClass]
public class Day03
{
    [TestClass]
    public class Part1
    {
        [TestMethod]
        public void BinaryDiagnostic()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day03.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(2743844, result);
        }

        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n").Select(l => l.Trim()).ToList();

            var gamma = new int[lines[0].Length];
            var epsilon = new int[lines[0].Length];
            for (var i = 0; i < lines[0].Length; i++)
            {
                var sum = lines.Sum(l => l[i] == '1' ? 1 : -1);
                gamma[i] = sum > 0 ? 1 : 0;
                epsilon[i] = sum < 0 ? 1 : 0;
            }

            return Convert.ToInt32(string.Join("", gamma), 2) * Convert.ToInt32(string.Join("", epsilon), 2);
        }
    }

    [TestClass]
    public class Part2
    {
        [TestMethod]
        public void BinaryDiagnostic()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day03.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(6677951, result);
        }

        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n").Select(l => l.Trim()).ToList();

            var oxygenLines = lines;
            var co2Lines = lines;
            for (var bitPosition = 0; bitPosition < lines[0].Length; bitPosition++)
            {
                if (oxygenLines.Count > 1)
                {
                    if (oxygenLines.Sum(l => l[bitPosition] == '1' ? 1 : -1) >= 0)
                    {
                        oxygenLines = oxygenLines.Where(l => l[bitPosition] == '1').ToList();
                    }
                    else
                    {
                        oxygenLines = oxygenLines.Where(l => l[bitPosition] == '0').ToList();
                    }
                }

                if (co2Lines.Count > 1)
                {
                    if (co2Lines.Sum(l => l[bitPosition] == '1' ? 1 : -1) >= 0)
                    {
                        co2Lines = co2Lines.Where(l => l[bitPosition] == '0').ToList();
                    }
                    else
                    {
                        co2Lines = co2Lines.Where(l => l[bitPosition] == '1').ToList();
                    }
                }
            }

            var oxygenRating = oxygenLines.First();
            var co2Rating = co2Lines.First();

            return Convert.ToInt32(string.Join("", oxygenRating), 2) * Convert.ToInt32(string.Join("", co2Rating), 2);
        }
    }
}