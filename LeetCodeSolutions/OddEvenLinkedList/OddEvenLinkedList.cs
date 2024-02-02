using System.Diagnostics.Tracing;

namespace LeetCodeSolutions;
public class OddEvenLinkedListSolution
{


    public ListNode OddEvenList(ListNode head)
    {
        int position = 1;
        ListNode? evensHead = null;
        ListNode? evensTail = null;
        ListNode? oddsHead = null;
        ListNode? oddsTail = null;

        while (head != null)
        {
            if (position % 2 == 0)
            {
                if (evensHead == null)
                {
                    evensHead = head;
                    evensTail = head;
                }
                else
                {
                    evensTail.next = head;
                    evensTail = evensTail.next;
                }
            }
            else
            {
                if (oddsHead == null)
                {
                    oddsHead = head;
                    oddsTail = head;
                }
                else
                {
                    oddsTail.next = head;
                    oddsTail = oddsTail.next;
                }
            }

            head = head.next;
            position++;
        }

        oddsTail.next = evensHead;
        evensTail.next = null;
        return oddsHead;


    }
}
