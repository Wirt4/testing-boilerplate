namespace LeetCodeSolutions;
public class ReverseLinkedListSolution
{
    private Stack<ListNode> PushAllToStack(ListNode head)
    {
        Stack<ListNode> nodeStack = new();
        ListNode cur = head;

        while (cur != null)
        {
            nodeStack.Push(cur);
            cur = cur.next;
        }

        return nodeStack;
    }

    private class ListWrapper
    {
        private readonly ListNode head;
        private ListNode tail;
        public ListWrapper(ListNode node)
        {
            head = node;
            head.next = null;
            tail = head;
        }

        public void Add(ListNode node)
        {
            tail.next = node;
            tail = tail.next;
        }

        public ListNode Head()
        {
            tail.next = null;
            return head;
        }
    }
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        Stack<ListNode> nodeStack = PushAllToStack(head);
        ListWrapper reversedList = new(nodeStack.Pop());

        while (nodeStack.Count > 0)
        {
            reversedList.Add(nodeStack.Pop());
        }

        return reversedList.Head();
    }
}
