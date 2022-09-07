using System;

namespace Leet
{
    class FirstMissingPositive
    {
        public FirstMissingPositive()
        {
            Check(new int[] { 1, 2, 0 }, 3);
            Check(new int[] { 3, 4, -1, 1 }, 2);
            Check(new int[] { 7, 8, 9, 11, 12 }, 1);
            Check(new int[] { 1, 8, 2, 4 }, 3);
            Check(new int[] { 1, 8, 4, 9, 2, 3 }, 5);
            Check(new int[] { 1, 8, 4, 9, 2, 3, 12, 17, 5, 7, 6 }, 10);
            Check(new int[] { 2147483647 }, 1);
        }

        void Check(int[] n, int expected)
        {
            int result = Do(n);
            Console.WriteLine($"{result == expected} => {string.Join(',', n)} = {result}, expected {expected}");
        }

        int Do(int[] nums)
        {
            bool[] found = new bool[100_000];
            found[0] = true;

            foreach (int v in nums)
            {
                if (v > 0 && v < 100_000)
                {
                    found[v] = true;
                }
            }

            for (int i = 0; i < found.Length; ++i)
            {
                if (!found[i])
                {
                    return i;
                }
            }

            return 100001;
        }
    }
}
