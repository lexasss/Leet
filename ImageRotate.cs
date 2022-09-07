using System;
using System.Linq;

namespace Leet
{
    class ImageRotate
    {
        public static void Run()
        {
            Check(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } },
                  new int[][] { new int[] { 7, 4, 1 }, new int[] { 8, 5, 2 }, new int[] { 9, 6, 3 } });
            Check(new int[][] { new int[] { 5, 1, 9, 11 }, new int[] { 2, 4, 8, 10 }, new int[] { 13, 3, 6, 7 }, new int[] { 15, 14, 12, 16 } },
                  new int[][] { new int[] { 15, 13, 2, 5 }, new int[] { 14, 3, 4, 1 }, new int[] { 12, 6, 8, 9 }, new int[] { 16, 7, 10, 11 } });
        }

        static void Check(int[][] matrix, int[][] expected)
        {
            Console.WriteLine(string.Join(',', matrix.Select(row => string.Join(',', row))));
            Rotate(matrix);
            Console.WriteLine(string.Join(',', matrix.Select(row => string.Join(',', row))));

            bool equal = true;
            for (int ri = 0; ri < matrix.Length; ++ri)
            {
                var row1 = matrix[ri];
                var row2 = expected[ri];
                for (int ci = 0; ci < row1.Length; ++ci)
                {
                    if (row1[ci] != row2[ci])
                    {
                        equal = false;
                        break;
                    }
                }
            }
            Console.WriteLine($" -> {equal}");
        }

        static void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            int half = n / 2;
            for (int ri = 0; ri < half; ++ri)
            {
                var rowTop = matrix[ri];
                var rowBottom = matrix[n - 1 - ri];
                for (int ci = ri; ci < n - 1 - ri; ++ci)
                {
                    int[] rowLeft = matrix[n - 1 - ci];
                    int[] rowRight = matrix[ci];

                    int left = rowLeft[ri];
                    rowLeft[ri] = rowBottom[n - 1 - ci];
                    rowBottom[n - 1 - ci] = rowRight[n - 1 - ri];
                    rowRight[n - 1 - ri] = rowTop[ci];
                    rowTop[ci] = left;
                }
            }
        }
    }
}
