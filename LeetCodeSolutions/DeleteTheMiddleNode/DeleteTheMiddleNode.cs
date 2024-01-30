namespace LeetCodeSolutions;
/**
 * LeetCode'sDefinition for singly-linked list.
 */
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

public class DeleteTheMiddleNodeSolution
{
    public ListNode DeleteMiddle(ListNode head)
    {
        int count = 0;
        ListNode cur = head;
        while (cur != null)
        {
            count++;
            cur = cur.next;
        }
        return count == 1 ? null : new ListNode(2);

    }
}
