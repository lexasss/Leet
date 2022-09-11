using System;

namespace Leet
{
    class JumpGame
    {
        public static void Run()
        {
            Check.Value(0, Jump, new int[] { 1 });
            Check.Value(3, Jump, new int[] { 1, 2, 3, 4, 5 });
            Check.Value(2, Jump, new int[] { 2, 3, 1, 1, 4 });
            Check.Value(2, Jump, new int[] { 2, 3, 0, 1, 4 });
            Check.Value(1, Jump, new int[] { 5, 3, 1, 1, 0 });
        }

        static int Jump(int[] nums)
        {
            int length = nums.Length;
            int[] jumps = new int[length];

            Array.Reverse(nums);

            jumps[0] = 0;

            for (int i = 1; i < length; ++i)
            {
                int val = nums[i];
                if (val == 0)
                {
                    jumps[i] = -1;  // -1 is an invalid value
                    continue;
                }

                int minJumpCount = int.MaxValue;
                for (int j = 1; j <= val && (i - j) >= 0; ++j)
                {
                    int jumpCount = jumps[i - j];
                    if (minJumpCount > jumpCount && jumpCount >= 0)
                    {
                        minJumpCount = jumpCount;
                    }
                }

                jumps[i] = minJumpCount + 1;
            }

            return jumps[length - 1];
        }
    }
}
