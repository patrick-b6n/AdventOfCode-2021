using System.Collections.Generic;

namespace AdventOfCode2021
{
    public static class ArrayExtensions
    {
        public static void ShiftRight<T>(this T[] arr)
        {
            var len = arr.Length;
            var tmp = arr[len - 1]; // save last element value
            for (var i = len - 1; i > 0; i--) // assign value of the previous element
            {
                arr[i] = arr[i - 1];
            }

            arr[0] = tmp; // last to first.
        }

        public static void ShiftRight<T>(this T[] arr, int times)
        {
            for (var i = 0; i < times; i++)
            {
                ShiftRight(arr);
            }
        }

        // https://github.com/InKahootz/AdventOfCode/blob/59106a94cecb7ed744ab435e6efac6a671c65a8a/csharp/Solutions/Utilities.cs#L200
        public static IEnumerable<T> SliceRow<T>(this T[,] arr, int row)
        {
            for (var i = 0; i < arr.GetLength(1); i++)
            {
                yield return arr[row, i];
            }
        }

        // https://github.com/InKahootz/AdventOfCode/blob/59106a94cecb7ed744ab435e6efac6a671c65a8a/csharp/Solutions/Utilities.cs#L208
        public static IEnumerable<T> SliceColumn<T>(this T[,] arr, int column)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                yield return arr[i, column];
            }
        }

        // https://stackoverflow.com/a/3150821/419956 by @RonWarholic
        public static IEnumerable<T> Flatten<T>(this T[,] map)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    yield return map[row, col];
                }
            }
        }
    }
}