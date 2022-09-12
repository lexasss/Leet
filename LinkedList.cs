using System;
using System.Collections.Generic;
using System.Text;

namespace Leet
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    class LinkedList
    {
        public static void SwapPairs()
        {
            Check.LinkedList(new ListNode(2, new ListNode(1, new ListNode(4, new ListNode(3)))),
                SwapPairs, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
        }

        static ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode first = head;
            ListNode second = head.next;

            ListNode result = second;

            ListNode prev = null;
            ListNode next;

            while (first != null && second != null)
            {
                next = second.next;
                second.next = first;
                first.next = next;

                if (prev != null)
                {
                    prev.next = second;
                }

                prev = first;
                first = next;
                second = first == null ? null : first.next;
            }

            return result;
        }
    }
}
