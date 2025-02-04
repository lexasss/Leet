﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Leet
{
    class Check
    {
        public delegate IEnumerable<T> ActionReturnsListDelegate<T,U>(U arg1);
        public delegate IList<IList<T>> ActionReturnsListOfListsDelegate<T, U>(U arg1);
        public delegate ListNode ActionReturnsLinkedListDelegate(ListNode arg1);
        public delegate ListNode ActionReturnsLinkedListDelegate2<T>(ListNode arg1, T arg2);
        public delegate void ActionReturnsVoidDelegate<T, U>(U arg1);
        public delegate T ActionReturnsValueDelegate1<T, U>(U arg1);
        public delegate T ActionReturnsValueDelegate2<T, U1, U2>(U1 arg1, U2 arg2);

        public class Options
        {
            public bool ModifiedInput { get; set; } = false;
        }

        public static void List<T,U>(IEnumerable<T> expected, ActionReturnsListDelegate<T, U> executor, U arg1)
        {
            var result = executor(arg1).OrderBy(s => s).ToList();
            bool isEqual = result.Count == expected.Count();
            if (isEqual)
            {
                isEqual = result.Except(expected).Count() == 0;
            }
            Console.WriteLine($"{isEqual} => {arg1} = {Stringify(result)}, expected {Stringify(expected)}]");
        }

        public static void List<T, U>(IList<IList<T>> expected, ActionReturnsListOfListsDelegate<T, U> executor, U arg1, Options options = default)
        {
            options = options ?? new Options();

            var a1 = Stringify(arg1);

            var result = executor(arg1);

            bool equals = true;
            for (int ri = 0; ri < result.Count; ++ri)
            {
                var row1 = result[ri];
                var row2 = expected[ri];
                for (int ci = 0; ci < row1.Count; ++ci)
                {
                    if (!EqualityComparer<T>.Default.Equals(row1[ci], row2[ci]))
                    {
                        equals = false;
                        break;
                    }
                }
            }

            string mi = options.ModifiedInput ? "=> " + Stringify(arg1) : "";

            Console.WriteLine($"{equals} => {a1} {mi} results to {Stringify(result)}, expected {Stringify(expected)}");
        }

        public static void List<T, U>(IList<IList<T>> expected, ActionReturnsVoidDelegate<T, U> executor, U arg1)
        {
            var a1 = Stringify(arg1);

            executor(arg1);

            var result = Stringify(arg1);
            var expectedStr = Stringify(expected);

            bool equals = expectedStr == result;

            Console.WriteLine($"{equals} => {a1} results to {result}, expected {expectedStr}");
        }

        public static void Value<T,U>(T expected, ActionReturnsValueDelegate1<T,U> executor, U arg1, Options options = default)
        {
            options = options ?? new Options();
            string a1 = Stringify(arg1);
            var result = executor(arg1);
            string mi = options.ModifiedInput && arg1 is IEnumerable<int> listModified ? "=> " + Stringify(listModified) : "";
            Console.WriteLine($"{EqualityComparer<T>.Default.Equals(result, expected)} => {a1} {mi} = {result}, expected {expected}");
        }

        public static void Value<T, U1, U2>(T expected, ActionReturnsValueDelegate2<T, U1, U2> executor, U1 arg1, U2 arg2, Options options = default)
        {
            options = options ?? new Options();
            string a1 = Stringify(arg1);
            string a2 = Stringify(arg2);
            var result = executor(arg1, arg2);
            string mi1 = options.ModifiedInput ? "=> " + Stringify(arg1) : "";
            Console.WriteLine($"{EqualityComparer<T>.Default.Equals(result, expected)} => {a1}|{a2} {mi1} = {result}, expected {expected}");
        }

        public static void LinkedList(ListNode expected, ActionReturnsLinkedListDelegate executor, ListNode arg1)
        {
            string argStr = Stringify(arg1);

            var result = executor(arg1);

            var r = result;
            var e = expected;
            bool isEqual;

            do
            {
                isEqual = expected.val == result.val;
                r = r.next;
                e = e.next;
            } while (isEqual && r != null && e != null);

            isEqual = isEqual && r == null && e == null;

            Console.WriteLine($"{isEqual} => {argStr} = {Stringify(result)}, expected {Stringify(expected)}");
        }

        public static void LinkedList<T>(ListNode expected, ActionReturnsLinkedListDelegate2<T> executor, ListNode arg1, T arg2)
        {
            string argStr = Stringify(arg1);

            var result = executor(arg1, arg2);

            var r = result;
            var e = expected;
            bool isEqual;

            do
            {
                isEqual = expected.val == result.val;
                r = r.next;
                e = e.next;
            } while (isEqual && r != null && e != null);

            isEqual = isEqual && r == null && e == null;

            Console.WriteLine($"{isEqual} => {argStr}|{Stringify(arg2)} = {Stringify(result)}, expected {Stringify(expected)}");
        }

        // Internal

        static string Stringify(object arg)
        {
            return arg switch
            {
                IList<IList<int>> listOfLists => "[" + string.Join(',', listOfLists.Select(row => "[" + string.Join(',', row) + "]")) + "]",
                IList<int> intList => "[" + string.Join(",", intList) + "]",
                IList<string> strList => "[" + string.Join(",", strList.Select(s => $"\"{s}\"")) + "]",
                ListNode node => "[" + node + "]",
                _ => arg.ToString()
            };
        }
    }
}
