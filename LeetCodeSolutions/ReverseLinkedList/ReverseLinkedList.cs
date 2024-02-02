namespace LeetCodeSolutions;
public class ReverseLinkedListSolution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode reversedList = ReverseList(head.next);
        head.next = null;
        ListNode tail = reversedList;
        while (tail != null && tail.next != null)
        {
            tail = tail.next;
        }
        tail.next = head;

        return reversedList;
    }
}
