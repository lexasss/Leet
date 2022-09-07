using System;

namespace Leet
{
    class LongestValidPar
    {
        public LongestValidPar()
        {
            Check("", 0);
            Check(")", 0);
            Check(")()", 2);
            Check("()", 2);
            Check("()(", 2);
            Check("())", 2);
            Check("())()()", 4);
            Check("()()", 4);
            Check("()(()", 2);

            Check("(())", 4);
            Check("(()())", 6);
            Check("(()())())", 8);
            Check("(()()))()", 6);
            Check("(()()(())", 8);
            Check("((())()()))(())()()()()(()()()()()()(()()", 12);
        }

        void Check(string s, int expected)
        {
            int result = Do(s);
            Console.WriteLine($"{result == expected} => {s} = {result}, expected {expected}");
        }

        int Do(string s)
        {
            int result = 0;

            int si = -1;

            int Next(int acc, bool hasOpened = false)
            {
                int longest = 0;

                while (++si < s.Length)
                {
                    char c = s[si];
                    if (c == '(')
                    {
                        longest = Next(longest, true);
                    }
                    else
                    {
                        return acc + longest + (hasOpened ? 2 : 0);
                    }
                }

                return Math.Max(acc, longest);
            }

            while (si < s.Length)
            {
                int length = Next(0);
                if (length > result)
                {
                    result = length;
                }
            }

            return result;
        }
    }
}
