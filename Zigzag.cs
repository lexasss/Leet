using System;

namespace Leet
{
    internal class Zigzag
    {
        public void Run()
        {
            Check.Value("A", Convert, "A", 1);
            Check.Value("AB", Convert, "AB", 1);
            Check.Value("ACBD", Convert, "ABCD", 2);
            Check.Value("PAHNAPLSIIGYIR", Convert, "PAYPALISHIRING", 3);
            Check.Value("PINALSIGYAHRPI", Convert, "PAYPALISHIRING", 4);
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
