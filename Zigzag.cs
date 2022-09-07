using System;
using System.Collections.Generic;
using System.Text;

namespace Leet
{
    internal class Zigzag
    {
        public void Run()
        {
            void Check(string s, int numRows, string expected)
            {
                var result = Convert(s, numRows);
                Console.WriteLine($"{result == expected} => {s} / {numRows} = {result}, expected {expected}");
            }

            Check("A", 1, "A");
            Check("AB", 1, "AB");
            Check("ABCD", 2, "ACBD");
            Check("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR");
            Check("PAYPALISHIRING", 4, "PINALSIGYAHRPI");
        }

        string Convert(string s, int numRows)
        {
            string result = "";

            int si = 0;
            int pi = 0;
            int row = 0;
            int chunkSize = Math.Max(2 * numRows - 2, 1);

            for (int i = 0; i < s.Length;)
            {
                if (si < s.Length)
                {
                    result += s[si];
                    ++i;

                    if (row > 0 && row < numRows - 1)
                    {
                        int sia = pi + chunkSize - row;
                        if (sia < s.Length)
                        {
                            result += s[sia];
                            ++i;
                        }
                    }
                }

                pi += chunkSize;

                if (pi > s.Length)
                {
                    ++row;
                    pi = 0;
                    si = row;
                }
                else
                {
                    si = pi + row;
                }
            }

            return result;
        }
    }
}
