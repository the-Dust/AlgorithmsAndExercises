using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Lc206
    {
        public void SelfTest()
        {
            var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var result = Calculate(head); // 5 4 3 2 1
        }

        public ListNode Calculate(ListNode head)
        {
            ListNode result = null;
            Func<ListNode, ListNode> inner = null;
            inner = h => {
                if (head != null && h.next != null)
                {
                    var r = inner(h.next);
                    h.next = null;
                    r.next = h;
                }
                else
                    result = h;
                return h;
            };
            inner(head);
            return result;
        }
    }
}
