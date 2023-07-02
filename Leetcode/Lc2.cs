using System.Numerics;

namespace Leetcode
{
    public class Lc2
    {
        public void SelfTest()
        {
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            AddTwoNumbers(l1, l2);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return AddTwoNumbers(l1, l2, 0);
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2, int rest)
        {
            if (l1 == null)
            {
                if (l2 == null)
                {
                    if (rest == 0)
                        return null;
                    else return new ListNode(rest);
                }
                return AddTwoNumbers(l2, l1, rest);
            }

            var num = l1.val + (l2?.val ?? 0) + rest;
            var val = num % 10;
            var n = num / 10;
            var result = new ListNode(val);
            result.next = AddTwoNumbers(l1.next, l2?.next, n);
            return result;
        }
    }

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

}
