using System;
using System.Collections.Generic;

namespace Leet
{
    class Parentheses
    {
        public static void LongestValidParentheses()
        {
            void Check(string s, int expected)
            {
                int result = LongestValidParentheses(s);
                Console.WriteLine($"{result == expected} => {s} = {result}, expected {expected}");
            }

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

        public static void IsCorrectSequence()
        {
            void Check(string s, bool expected)
            {
                var result = IsCorrectSequence(s);
                Console.WriteLine($"{result == expected} => {s} = {result}, expected {expected}");
            }

            Check("()", true);
            Check("()[]{}", true);
            Check("(]", false);
            Check("]", false);
            Check("(){", false);
            Check("{[]}", true);
        }

        static int LongestValidParentheses(string s)
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

        static bool IsCorrectSequence(string s)
        {
            Dictionary<char, char> pairs = new()
            {
                { '[', ']' },
                { '{', '}' },
                { '(', ')' },
            };

            Stack<char> expecting = new();
            foreach (char c in s)
            {
                if (expecting.Count > 0)
                {
                    char exp = expecting.Peek();
                    if (exp != c)
                    {
                        if (pairs.ContainsKey(c))
                        {
                            expecting.Push(pairs[c]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        expecting.Pop();
                    }
                }
                else
                {
                    if (pairs.ContainsKey(c))
                    {
                        expecting.Push(pairs[c]);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return expecting.Count == 0;
        }
    }
}
