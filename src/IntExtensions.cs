namespace AdventOfCode2021;

public static class IntExtensions
{
    public static int TriangularNumber(this int n)
    {
        return n * (n + 1) / 2;
    }
}