using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021;

[TestClass]
public class Day06
{
    /// <summary>
    /// Solved with the help of reddit. I was stuck at loops, even with a math approach.
    /// 
    /// Just keep how many fishes have timer X (position in array)
    /// The timer decreases each day, which equals a shift left.
    /// The default wrap-around creates new fishes on index 8.
    /// The existing fishes are added to index 6.
    /// </summary>
    private static long EvolveFishes(IReadOnlyCollection<int> fishes, int totalDays)
    {
        var counts = new long[9];
        for (var i = 0; i < 8; i++)
        {
            counts[i] = fishes.Count(n => n == i);
        }

        for (var i = 0; i < totalDays; i++)
        {
            counts.ShiftLeft();
            counts[6] += counts[8];
        }

        return counts.Sum();
    }

    [TestClass]
    public class Part1
    {
        [TestMethod]
        public void LanternFish()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day06.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(388419, result);
        }

        private static long Solve(string input)
        {
            var fishes = input.Trim().Split(",").Select(int.Parse).ToList();
            return EvolveFishes(fishes, 80);
        }
    }

    [TestClass]
    public class Part2
    {
        [TestMethod]
        public void LanternFish()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day06.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(1740449478328, result);
        }

        private static long Solve(string input)
        {
            var fishes = input.Trim().Split(",").Select(int.Parse).ToList();
            return EvolveFishes(fishes, 256);
        }
    }
}