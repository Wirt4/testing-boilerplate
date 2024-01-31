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
    private int getLength(ListNode head)
    {
        int count = 0;
        ListNode cur = head;

        while (cur != null)
        {
            count++;
            cur = cur.next;
        }
        return count;
    }
    public ListNode DeleteMiddle(ListNode head)
    {
        int count = getLength(head);

        if (count == 1)
        {
            return null;
        }

        if (count == 2)
        {

            head.next = null;
            return head;

        }

        int halfwayMark = count / 2; // 1

        ListNode prev = head;
        ListNode cur = head.next;

        halfwayMark--;

        while (halfwayMark > 0)
        {
            cur = cur.next;
            prev = prev.next;
            halfwayMark--;
        }

        prev.next = cur.next;
        cur.next = null;
        // c# has automatic garbage collection, nullify the references and the memory will be realocated
        return head;


    }
}
