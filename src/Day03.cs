using System;
using System.Collections;
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

            var arr = new BitArray(lines[0].Length);
            for (var bitPosition = 0; bitPosition < lines[0].Length; bitPosition++)
            {
                var sum = lines.Sum(l => l[bitPosition] == '1' ? 1 : -1);
                arr[bitPosition] = sum > 0;
            }

            return arr.ToInt() * arr.Not().ToInt();
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

            return oxygenRating.BinToInt() * co2Rating.BinToInt();
        }
    }
}

internal static class Day03Helper
{
    public static int BinToInt(this string str)
    {
        return Convert.ToInt32(str, 2);
    }

    public static int ToInt(this BitArray bitArray)
    {
        var val = 0;
        for (var i = 0; i < bitArray.Count; i++)
        {
            if (bitArray[i])
            {
                val += (int)Math.Pow(2, bitArray.Count - 1 - i);
            }
        }

        return val;
    }
}