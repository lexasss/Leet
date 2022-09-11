namespace Leet
{
    class FirstMissingPositive
    {
        public static void Run()
        {
            Check.Value(3, FirstMissingPositiveInt, new int[] { 1, 2, 0 });
            Check.Value(2, FirstMissingPositiveInt, new int[] { 3, 4, -1, 1 });
            Check.Value(1, FirstMissingPositiveInt, new int[] { 7, 8, 9, 11, 12 });
            Check.Value(3, FirstMissingPositiveInt, new int[] { 1, 8, 2, 4 });
            Check.Value(5, FirstMissingPositiveInt, new int[] { 1, 8, 4, 9, 2, 3 });
            Check.Value(10, FirstMissingPositiveInt, new int[] { 1, 8, 4, 9, 2, 3, 12, 17, 5, 7, 6 });
            Check.Value(1, FirstMissingPositiveInt, new int[] { 2147483647 });
        }

        static int FirstMissingPositiveInt(int[] nums)
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
