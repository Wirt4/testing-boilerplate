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
        switch (count)
        {
            case 1:
                return null;
            case 2:
                head.next = null;
                break;
            default:
                int halfwayMark = count / 2;
                ListNode prev = head;
                halfwayMark--;

                while (halfwayMark > 1)
                {
                    prev = prev.next;
                    halfwayMark--;
                }

                prev.next = prev.next.next;
                break;
        }
        return head;
    }
}
