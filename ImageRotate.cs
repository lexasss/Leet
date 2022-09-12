using System;
using System.Linq;

namespace Leet
{
    class ImageRotate
    {
        public static void Run()
        {
            Check.List(new int[][] { new int[] { 7, 4, 1 }, new int[] { 8, 5, 2 }, new int[] { 9, 6, 3 } },
                Rotate, new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } });
            Check.List(new int[][] { new int[] { 15, 13, 2, 5 }, new int[] { 14, 3, 4, 1 }, new int[] { 12, 6, 8, 9 }, new int[] { 16, 7, 10, 11 } },
                Rotate, new int[][] { new int[] { 5, 1, 9, 11 }, new int[] { 2, 4, 8, 10 }, new int[] { 13, 3, 6, 7 }, new int[] { 15, 14, 12, 16 } });
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
