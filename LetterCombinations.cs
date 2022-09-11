using System;
using System.Collections.Generic;
using System.Linq;

namespace Leet
{
    class LetterCombinations
    {
        public static void Run()
        {
            Check.List(new string[] { }, GetLetterCombinations, "");
            Check.List(new string[] { "a", "b", "c" }, GetLetterCombinations, "2");
            Check.List(new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }, GetLetterCombinations, "23");
        }

        static Dictionary<char, string> KEYBOARD = new()
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
        };

        static IList<string> GetLetterCombinations(string digits)
        {
            List<string> result = new();

            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }

            HashSet<char> initial = new(KEYBOARD[digits[0]]);
            result.AddRange(initial.Select(c => c.ToString()));

            for (int i = 1; i < digits.Length; ++i)
            {
                string letters = KEYBOARD[digits[i]];
                List<string> newResult = new();
                foreach (char letter in letters)
                {
                    foreach (string r in result)
                    {
                        newResult.Add(r + letter);
                    }
                }
                result = newResult;
            }

            return result;
        }
    }
}
