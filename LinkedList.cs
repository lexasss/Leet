using System.Collections.Generic;

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
        public override string ToString()
        {
            List<int> list = new();
            ListNode node = this;
            while (node != null)
            {
                list.Add(node.val);
                node = node.next;
            }
            return string.Join(',', list);
        }
    }

    class LinkedList
    {
        public static void SwapPairs()
        {
            Check.LinkedList(new ListNode(2, new ListNode(1, new ListNode(4, new ListNode(3)))),
                SwapPairs, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
        }

        public static void ReverseKGroup()
        {
            Check.LinkedList(new ListNode(1, new ListNode(2)),
                ReverseKGroup, new ListNode(1, new ListNode(2)), 1);
            Check.LinkedList(new ListNode(1, new ListNode(2)),
                ReverseKGroup, new ListNode(1, new ListNode(2)), 3);
            Check.LinkedList(new ListNode(2, new ListNode(1)),
                ReverseKGroup, new ListNode(1, new ListNode(2)), 2);
            Check.LinkedList(new ListNode(2, new ListNode(1, new ListNode(4, new ListNode(3, new ListNode(6, new ListNode(5, new ListNode(7))))))),
                ReverseKGroup, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7))))))), 2);
            Check.LinkedList(new ListNode(3, new ListNode(2, new ListNode(1, new ListNode(6, new ListNode(5, new ListNode(4, new ListNode(7))))))),
                ReverseKGroup, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7))))))), 3);
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

        static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 1)
            {
                return head;
            }

            ListNode chunkHead = head;
            ListNode chunkTailPrev = null;
            ListNode newHead = null;

            Stack<ListNode> stack = new();
            while (chunkHead != null)
            {
                for (int i = 0; i < k; ++i)
                {
                    if (chunkHead == null)
                    {
                        return newHead ?? head;
                    }

                    stack.Push(chunkHead);
                    chunkHead = chunkHead.next;
                }

                ListNode newChunkHead = stack.Pop();
                ListNode node = newChunkHead;
                while (stack.Count > 0)
                {
                    var nextNode = stack.Pop();
                    node.next = nextNode;
                    node = nextNode;
                }

                if (chunkTailPrev != null)
                {
                    chunkTailPrev.next = newChunkHead;
                }
                if (newHead == null)
                {
                    newHead = newChunkHead;
                }

                chunkTailPrev = node;
                chunkTailPrev.next = chunkHead;
            }

            /*
            bool isLongEnough(ListNode node)
            {
                int count = k;
                while (node != null && count > 0)
                {
                    node = node.next;
                    --count;
                }
                return count == 0;
            }

            while (isLongEnough(chunkHead))
            {
                ListNode newChunkTailPrev = chunkHead;

                int count = k;
                ListNode node = chunkHead.next;

                while (count > 1)
                {
                    var prev = node.next;
                    node.next = chunkHead;
                    chunkHead = node;

                    --count;

                    node = prev;
                }

                // chunkHead is indeed the head of the reversed chunk;
                if (newHead == null)
                {
                    newHead = chunkHead;
                }
                if (chunkTailPrev != null)
                {
                    chunkTailPrev.next = chunkHead;
                }
                chunkTailPrev = newChunkTailPrev;

                chunkHead = node; // next chunk head
            }
            
            if (chunkTailPrev != null)
            {
                chunkTailPrev.next = chunkHead;
            }
            */

            return newHead ?? head;
        }
    }
}
