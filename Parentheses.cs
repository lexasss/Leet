using System;
using System.Collections.Generic;

namespace Leet
{
    class Parentheses
    {
        public static void LongestValidParentheses()
        {
            Check.Value(0, LongestValidParentheses, "");
            Check.Value(0, LongestValidParentheses, ")");
            Check.Value(2, LongestValidParentheses, ")()");
            Check.Value(2, LongestValidParentheses, "()");
            Check.Value(2, LongestValidParentheses, "()(");
            Check.Value(2, LongestValidParentheses, "())");
            Check.Value(4, LongestValidParentheses, "())()()");
            Check.Value(4, LongestValidParentheses, "()()");
            Check.Value(2, LongestValidParentheses, "()(()");

            Check.Value(4, LongestValidParentheses, "(())");
            Check.Value(6, LongestValidParentheses, "(()())");
            Check.Value(8, LongestValidParentheses, "(()())())");
            Check.Value(6, LongestValidParentheses, "(()()))()");
            Check.Value(8, LongestValidParentheses, "(()()(())");
            Check.Value(12, LongestValidParentheses, "((())()()))(())()()()()(()()()()()()(()()");
        }

        public static void IsCorrectSequence()
        {
            Check.Value(true, IsCorrectSequence, "()");
            Check.Value(true, IsCorrectSequence, "()[]{}");
            Check.Value(false, IsCorrectSequence, "(]");
            Check.Value(false, IsCorrectSequence, "]");
            Check.Value(false, IsCorrectSequence, "(){");
            Check.Value(true, IsCorrectSequence, "{[]}");
        }

        public static void GenerateParenthesis()
        {
            Check.List(new List<string> { "()" }, GenerateParenthesis, 1);
            Check.List(new List<string> { "(())", "()()" }, GenerateParenthesis, 2);
            Check.List(new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" }, GenerateParenthesis, 3);
            Check.List(new List<string> { "(((())))", "((()()))", "((())())", "((()))()", "(()(()))", "(()()())", "(()())()", "(())(())", "(())()()", "()((()))", "()(()())", "()(())()", "()()(())", "()()()()" }, GenerateParenthesis, 4);
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

        static IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new();

            void Add(int opened, int closed, string s)
            {
                if (opened < n)
                {
                    Add(opened + 1, closed, s + "(");
                }
                if (closed < n && closed < opened)
                {
                    Add(opened, closed + 1, s + ")");
                }

                if (opened == n && closed == n)
                {
                    result.Add(s);
                }
            }

            Add(0, 0, "");

            return result;
        }
    }
}
