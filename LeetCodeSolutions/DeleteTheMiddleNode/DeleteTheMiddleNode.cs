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
// end of leetcode boilerplate

public class DeleteTheMiddleNodeSolution
{
    private int getLength(ListNode head)
    {
        int count = 0;

        while (head != null)
        {
            count++;
            head = head.next;
        }
        return count;
    }

    private ListNode RemoveFirst()
    {
        return null;
    }

    private ListNode RemoveLast(ListNode head)
    {
        return new ListNode(head.val);
    }

    private ListNode RemoveMiddle(ListNode head, int length)
    {
        ListNode cur = head;
        int positionBeforeHalfway = length / 2 - 1;

        for (int i = 0; i < positionBeforeHalfway; i++)
        {
            cur = cur.next;
        }

        cur.next = cur.next.next;
        return head;
    }

    public ListNode DeleteMiddle(ListNode head)
    {
        int length = getLength(head);
        return length switch
        {
            1 => RemoveFirst(),
            2 => RemoveLast(head),
            _ => RemoveMiddle(head, length),
        };
    }
}
