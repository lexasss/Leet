using System;
using System.Collections.Generic;
using System.Text;

namespace Leet
{
    class Match
    {
		public static void Run()
        {
			Check("", "", true);
			Check("", "b", false);
			Check("a", "", false);

			Check("a", "a", true);
			Check("aa", "a", false);
			Check("aa", "aaa", false);
			Check("a", "b", false);
			Check("ab", "ab", true);
			Check("aab", "ab", false);
			Check("ab", "abb", false);

			Check("b", "?*?", false);
			Check("ab", "?b", true);
			Check("ab", "a?", true);
			Check("ab", "a??", false);
			Check("asas", "*?", true);

			Check("", "*?", false);
			Check("", "*", true);

			Check("aab", "*b", true);
			Check("aab", "*b*", true);
			Check("aab", "*c*", false);
			Check("aab", "*b?", false);
			Check("aab", "*a?", true);
			Check("aab", "b*", false);
			Check("aab", "**a", false);
			Check("aab", "**b", true);
			Check("aab", "a*b", true);
			Check("aab", "a*c", false);

			Check("aacab", "*c*b", true);
			Check("aacab", "*c?b", true);
			Check("aacabd", "*c?b", false);
			Check("aaccab", "*c?b", true);
			Check("aaccab", "*cab", true);
			Check("aaccab", "aac*b", true);
			Check("aaccab", "a*c*b", true);
			Check("aaccab", "a*b*b", false);

			Check("abcabczzzde", "*abc???de*", true);
			Check("abcabczzzde", "*abc*ad*", false);
			Check("abcaaaazzzde", "*abc*az*", true);
			Check("abcaaaazzzde", "*abc*zzzzd*", false);
			Check("abcaaaazzzde", "*abc*zzdd*", false);

			Check("abczzz", "*abc???*", true);
			Check("abczzzde", "*abc???*", true);
			Check("abczzzde", "*abc???de*", true);
			Check("abcabczzzdeXabczzzdede", "*abc???de*abc???de*", true);
		}

		enum Dir
		{
			Forward,
			Backward
		}

		static void Check(string s, string p, bool expected)
		{
			bool result = IsMatch(s, p);
			string eq = result ? "==" : "!=";
			Console.WriteLine($"{result == expected} : \"{s}\" {eq} \"{p}\"");
		}

		static bool IsMatch(string s, string p)
		{
			string[] ps = p?.Split('*');

			if (ps?.Length == 0)
			{
				return true;
			}

			int start = 0;
			int end = s.Length - 1;

			// First sequence
			if (!Get(s, ps[0], ref start, Dir.Forward))
			{
				return false;
			}

			// Last sequence
			if (ps.Length > 1)
			{
				if (!Get(s, ps[ps.Length - 1], ref end, Dir.Backward, start - 1))
				{
					return false;
				}
			}
			else
			{
				return start > end;
			}

			int psi = 1;
			++end;  // now this is the next index after the last valid

			while (psi < ps.Length - 1)
			{
				string psp = ps[psi];
				if (start > end - psp.Length)
				{
					return false;
				}

				int i = start;
				if (Search(s, psp, ref i, end))
				{
					start = i;
					++psi;
				}
				else
				{
					++start;
				}
			}

			return true;
		}

		static bool Get(string s, string p, ref int si, Dir dir, int firstInvalidIndex = -1)
		{
			int inc = dir == Dir.Forward ? 1 : -1;
			int pi = dir == Dir.Forward ? 0 : p.Length - 1;

			for (; pi >= 0 && pi < p.Length; pi += inc, si += inc)
			{
				if (si < 0 || si == s.Length || si == firstInvalidIndex)
				{
					return false;
				}

				char pc = p[pi];
				if (pc == '?')
				{
					continue;
				}

				char sc = s[si];
				if (sc != pc)
				{
					return false;
				}
			}
			return true;
		}

		static bool Search(string s, string p, ref int start, int end)
		{
			int si = start;
			int pi = 0;
			for (; si < end && pi < p.Length; ++si, ++pi)
			{
				char sc = s[si];
				char pc = p[pi];
				if (pc != '?' && pc != sc)
				{
					return false;
				}
			}

			start = si;
			return true;
		}
	}
}
