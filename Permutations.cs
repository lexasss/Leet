using System;
using System.Collections.Generic;
using System.Linq;

namespace Leet
{
    class Permutations
    {
        public static void Run()
        {
            Check(new int[] { 1 },
                  new int[][] { new int[] { 1 } });
            Check(new int[] { 1, 2 },
                  new int[][] { new int[] { 1, 2 }, new int[] { 2, 1 } });
            Check(new int[] { 1, 2, 3 },
                  new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 }, new int[] { 2, 1,3  }, new int[] { 2, 3, 1 }, new int[] { 3, 1, 2 }, new int[] { 3, 2, 1 } });
            Check(new int[] { 1, 2, 3, 4 },
                  new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4, 3 },
                                new int[] { 1, 3, 2, 4 }, new int[] { 1, 3, 4, 2 },
                                new int[] { 1, 4, 2, 3 }, new int[] { 1, 4, 3, 2 },
                                new int[] { 2, 1, 3, 4 }, new int[] { 2, 1, 4, 3 },
                                new int[] { 2, 3, 1, 4 }, new int[] { 2, 3, 4, 1 },
                                new int[] { 2, 4, 1, 3 }, new int[] { 2, 4, 3, 1 },
                                new int[] { 3, 1, 2, 4 }, new int[] { 3, 1, 4, 2 },
                                new int[] { 3, 2, 1, 4 }, new int[] { 3, 2, 4, 1 },
                                new int[] { 3, 4, 1, 2 }, new int[] { 3, 4, 2, 1 },
                                new int[] { 4, 1, 2, 3 }, new int[] { 4, 1, 3, 2 },
                                new int[] { 4, 2, 1, 3 }, new int[] { 4, 2, 3, 1 },
                                new int[] { 4, 3, 1, 2 }, new int[] { 4, 3, 2, 1 }});
        }

        static void Check(int[] nums, int[][] expected)
        {
            var r = Permute(nums);

            var s1 = "[" + string.Join(',', nums) + "]";
            var s2 = "[" + string.Join(", ", r.Select(row => "[" + string.Join(',', row) + "]")) + "]";
            var s3 = "[" + string.Join(", ", expected.Select(row => "[" + string.Join(',', row) + "]")) + "]";

            bool equal = true;
            for (int ri = 0; ri < r.Count; ++ri)
            {
                var row1 = r[ri];
                var row2 = expected[ri];
                for (int ci = 0; ci < row1.Count; ++ci)
                {
                    if (row1[ci] != row2[ci])
                    {
                        equal = false;
                        break;
                    }
                }
            }
            Console.WriteLine($"{equal} => {s1} results to {s2}, expected {s3}");
        }

        static IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new();

            for (int i = 0; i < nums.Length; ++i)
            {
                int val = nums[i];
                if (nums.Length > 1)
                {
                    int[] slice = nums.Where((item, index) => i != index).ToArray();
                    var lists = Permute(slice);
                    foreach (var list in lists)
                    {
                        list.Insert(0, val);
                        result.Add(list);
                    }
                }
                else
                {
                    result.Add(new List<int>() { val });
                }
            }

            return result;
        }
    }
}
