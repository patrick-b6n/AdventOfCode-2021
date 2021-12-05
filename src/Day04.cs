using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2021;

[TestClass]
public class Day04
{
    private static List<int[,]> BuildBoards(IReadOnlyList<string> lines)
    {
        var boards = new List<int[,]>();
        for (var i = 2; i < lines.Count; i += 6)
        {
            var board = new int[5, 5];

            for (var j = 0; j < 5; j++)
            {
                var line = lines[i + j].Trim();
                var ns = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                for (var ni = 0; ni < ns.Count; ni++)
                {
                    board[j, ni] = ns[ni];
                }
            }

            boards.Add(board);
        }

        return boards;
    }

    private static int GetScore(int[,] board)
    {
        return board.Flatten().Where(n => n != -1).Sum();
    }

    private static bool HasWon(int[,] board)
    {
        for (var i = 0; i < board.GetLength(0); i++)
        {
            if (board.SliceRow(i).All(n => n == -1))
            {
                return true;
            }

            if (board.SliceColumn(i).All(n => n == -1))
            {
                return true;
            }
        }

        return false;
    }

    [TestClass]
    public class Part1
    {
        [TestMethod]
        public void GiantSquid()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day04.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(12796, result);
        }

        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n").Select(l => l.Trim()).ToList();
            var boards = BuildBoards(lines);
            var numbers = lines[0].Trim().Split(",").Select(int.Parse);

            foreach (var drawnNumber in numbers)
            {
                foreach (var board in boards)
                {
                    for (var i = 0; i < board.GetLength(0); i++)
                    {
                        for (var j = 0; j < board.GetLength(1); j++)
                        {
                            if (board[i, j] == drawnNumber)
                            {
                                board[i, j] = -1;
                            }
                        }
                    }

                    if (HasWon(board))
                    {
                        return GetScore(board) * drawnNumber;
                    }
                }
            }

            return -1;
        }
    }

    [TestClass]
    public class Part2
    {
        [TestMethod]
        public void GiantSquid()
        {
            var input = TestHelper.ReadEmbeddedFile(GetType().Assembly, "Input.Day04.txt");
            var result = Solve(input);

            Console.WriteLine(result);
            Assert.AreEqual(18063, result);
        }


        private static int Solve(string input)
        {
            var lines = input.Trim().Split("\n").Select(l => l.Trim()).ToList();
            var boards = BuildBoards(lines);
            var numbers = lines[0].Trim().Split(",").Select(int.Parse);

            foreach (var drawnNumber in numbers)
            {
                foreach (var board in boards)
                {
                    for (var i = 0; i < board.GetLength(0); i++)
                    {
                        for (var j = 0; j < board.GetLength(1); j++)
                        {
                            if (board[i, j] == drawnNumber)
                            {
                                board[i, j] = -1;
                            }
                        }
                    }
                }

                for (var i = 0; i < boards.Count; i++)
                {
                    var board = boards[i];
                    if (HasWon(board))
                    {
                        if (boards.Count > 1)
                        {
                            boards.Remove(board);
                            i--;
                        }
                        else
                        {
                            return GetScore(board) * drawnNumber;
                        }
                    }
                }
            }

            return -1;
        }
    }
}