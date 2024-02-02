using System.Globalization;

namespace LeetCodeSolutions;
public class ReverseLinkedListSolution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        Stack<ListNode> nodeStack = new();
        ListNode cur = head;

        while (cur != null)
        {
            nodeStack.Push(cur);
            cur = cur.next;
        }

        ListNode returnHead = nodeStack.Pop();
        returnHead.next = null;
        ListNode tail = returnHead;

        while (nodeStack.Count > 0)
        {
            tail.next = nodeStack.Pop();
            tail = tail.next;
        }

        tail.next = null;

        return returnHead;
    }
}
