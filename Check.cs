using System;
using System.Collections.Generic;
using System.Linq;

namespace Leet
{
    class Check
    {
        public delegate IEnumerable<T> ActionReturnsListDelegate<T,U>(U arg1);
        public delegate IList<IList<T>> ActionReturnsListOfListsDelegate<T, U>(U arg1);
        public delegate T ActionReturnsValueDelegate1<T, U>(U arg1);
        public delegate T ActionReturnsValueDelegate2<T, U1, U2>(U1 arg1, U2 arg2);

        public static void List<T,U>(IEnumerable<T> expected, ActionReturnsListDelegate<T, U> executor, U arg1)
        {
            var result = executor(arg1).OrderBy(s => s).ToList();
            bool isEqual = result.Count == expected.Count();
            if (isEqual)
            {
                isEqual = result.Except(expected).Count() == 0;
            }
            Console.WriteLine($"{isEqual} => {arg1} = [{string.Join(",", result.Select(s => $"\"{s}\""))}], expected [{string.Join(",", expected.Select(s => $"\"{s}\""))}]");
        }

        public static void List<T, U>(IList<IList<T>> expected, ActionReturnsListOfListsDelegate<T, U> executor, U arg1)
        {
            var result = executor(arg1);

            var s1 = arg1 is IList<IList<int>> listOfLists
                ? "[" + string.Join(',', listOfLists.Select(row => "[" + string.Join(',', row) + "]")) + "]"
                : (arg1 is IList<int> list
                    ? "[" + string.Join(",", list) + "]"
                    : arg1.ToString());
            var s2 = "[" + string.Join(", ", result.Select(row => "[" + string.Join(',', row) + "]")) + "]";
            var s3 = "[" + string.Join(", ", expected.Select(row => "[" + string.Join(',', row) + "]")) + "]";

            bool equal = true;
            for (int ri = 0; ri < result.Count; ++ri)
            {
                var row1 = result[ri];
                var row2 = expected[ri];
                for (int ci = 0; ci < row1.Count; ++ci)
                {
                    if (!EqualityComparer<T>.Default.Equals(row1[ci], row2[ci]))
                    {
                        equal = false;
                        break;
                    }
                }
            }
            Console.WriteLine($"{equal} => {s1} results to {s2}, expected {s3}");
        }

        public static void Value<T,U>(T expected, ActionReturnsValueDelegate1<T,U> executor, U arg1)
        {
            var result = executor(arg1);
            string a1 = arg1 is IEnumerable<int> list ? string.Join(",", list) : arg1.ToString();
            Console.WriteLine($"{EqualityComparer<T>.Default.Equals(result, expected)} => {a1} = {result}, expected {expected}");
        }

        public static void Value<T, U1, U2>(T expected, ActionReturnsValueDelegate2<T, U1, U2> executor, U1 arg1, U2 arg2)
        {
            var result = executor(arg1, arg2);
            string a1 = arg1 is IEnumerable<int> list1 ? string.Join(",", list1) : arg1.ToString();
            string a2 = arg2 is IEnumerable<int> list2 ? string.Join(",", list2) : arg2.ToString();
            Console.WriteLine($"{EqualityComparer<T>.Default.Equals(result, expected)} => {a1}|{a2} = {result}, expected {expected}");
        }
    }
}
