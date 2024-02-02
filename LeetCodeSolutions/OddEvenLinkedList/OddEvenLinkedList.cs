using System.Diagnostics.Tracing;

namespace LeetCodeSolutions;
public class OddEvenLinkedListSolution
{
    private class ListWrapper
    {
        public ListNode Head;
        public ListNode Tail;
    }

    public ListNode OddEvenList(ListNode head)
    {
        int position = 1;
        ListWrapper evens = new();
        ListWrapper odds = new();

        while (head != null)
        {
            if (position % 2 == 0)
            {
                if (evens.Head == null)
                {
                    evens.Head = head;
                    evens.Tail = head;
                }
                else
                {
                    evens.Tail.next = head;
                    evens.Tail = evens.Tail.next;
                }
            }
            else
            {
                if (odds.Head == null)
                {
                    odds.Head = head;
                    odds.Tail = head;
                }
                else
                {
                    odds.Tail.next = head;
                    odds.Tail = odds.Tail.next;
                }
            }

            head = head.next;
            position++;
        }

        odds.Tail.next = evens.Head;
        evens.Tail.next = null;
        return odds.Head;


    }
}
