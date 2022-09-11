using System;
using System.Collections.Generic;
using System.Linq;

namespace Leet
{
    class Permutations
    {
        public static void Run()
        {
            Check.List(new int[][] { new int[] { 1 } },
                Permute, new int[] { 1 });
            Check.List(new int[][] { new int[] { 1, 2 }, new int[] { 2, 1 } },
                Permute, new int[] { 1, 2 });
            Check.List(new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 },
                                     new int[] { 2, 1,3  }, new int[] { 2, 3, 1 },
                                     new int[] { 3, 1, 2 }, new int[] { 3, 2, 1 } },
                Permute, new int[] { 1, 2, 3 });
            Check.List(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4, 3 },
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
                                     new int[] { 4, 3, 1, 2 }, new int[] { 4, 3, 2, 1 }},
                Permute, new int[] { 1, 2, 3, 4 });
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
