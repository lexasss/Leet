using System;
using System.Collections.Generic;
using System.Text;

namespace Leet
{
    class Match
    {
		public static void Run()
        {
			Check.Value(true, IsMatch, "", "");
			Check.Value(false, IsMatch, "", "b");
			Check.Value(false, IsMatch, "a", "");

			Check.Value(true, IsMatch, "a", "a");
			Check.Value(false, IsMatch, "aa", "a");
			Check.Value(false, IsMatch, "aa", "aaa");
			Check.Value(false, IsMatch, "a", "b");
			Check.Value(true, IsMatch, "ab", "ab");
			Check.Value(false, IsMatch, "aab", "ab");
			Check.Value(false, IsMatch, "ab", "abb");

			Check.Value(false, IsMatch, "b", "?*?");
			Check.Value(true, IsMatch, "ab", "?b");
			Check.Value(true, IsMatch, "ab", "a?");
			Check.Value(false, IsMatch, "ab", "a??");
			Check.Value(true, IsMatch, "asas", "*?");

			Check.Value(false, IsMatch, "", "*?");
			Check.Value(true, IsMatch, "", "*");

			Check.Value(true, IsMatch, "aab", "*b");
			Check.Value(true, IsMatch, "aab", "*b*");
			Check.Value(false, IsMatch, "aab", "*c*");
			Check.Value(false, IsMatch, "aab", "*b?");
			Check.Value(true, IsMatch, "aab", "*a?");
			Check.Value(false, IsMatch, "aab", "b*");
			Check.Value(false, IsMatch, "aab", "**a");
			Check.Value(true, IsMatch, "aab", "**b");
			Check.Value(true, IsMatch, "aab", "a*b");
			Check.Value(false, IsMatch, "aab", "a*c");

			Check.Value(true, IsMatch, "aacab", "*c*b");
			Check.Value(true, IsMatch, "aacab", "*c?b");
			Check.Value(false, IsMatch, "aacabd", "*c?b");
			Check.Value(true, IsMatch, "aaccab", "*c?b");
			Check.Value(true, IsMatch, "aaccab", "*cab");
			Check.Value(true, IsMatch, "aaccab", "aac*b");
			Check.Value(true, IsMatch, "aaccab", "a*c*b");
			Check.Value(false, IsMatch, "aaccab", "a*b*b");

			Check.Value(true, IsMatch, "abcabczzzde", "*abc???de*");
			Check.Value(false, IsMatch, "abcabczzzde", "*abc*ad*");
			Check.Value(true, IsMatch, "abcaaaazzzde", "*abc*az*");
			Check.Value(false, IsMatch, "abcaaaazzzde", "*abc*zzzzd*");
			Check.Value(false, IsMatch, "abcaaaazzzde", "*abc*zzdd*");

			Check.Value(true, IsMatch, "abczzz", "*abc???*");
			Check.Value(true, IsMatch, "abczzzde", "*abc???*");
			Check.Value(true, IsMatch, "abczzzde", "*abc???de*");
			Check.Value(true, IsMatch, "abcabczzzdeXabczzzdede", "*abc???de*abc???de*");
		}

		enum Dir
		{
			Forward,
			Backward
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
