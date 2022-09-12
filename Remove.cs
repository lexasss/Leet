namespace Leet
{
    class Remove
    {
        public static void Run()
        {
            Check.Value(2, RemoveElement, new int[] { 3, 2, 2, 3 }, 3, new Check.Options { ModifiedInput = true } );
            Check.Value(5, RemoveElement, new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new Check.Options { ModifiedInput = true });
            Check.Value(5, RemoveElement, new int[] { 8, 7, 8, 3, 2, 0, 8, 11 }, 8, new Check.Options { ModifiedInput = true });
        }

        static int RemoveElement(int[] nums, int val)
        {
            int j = 0;
            int length = nums.Length;
            for (int i = 0; i < length; ++i)
            {
                if (nums[i] != val)
                {
                    nums[j++] = nums[i];
                }
            }

            return j;
        }
    }
}
