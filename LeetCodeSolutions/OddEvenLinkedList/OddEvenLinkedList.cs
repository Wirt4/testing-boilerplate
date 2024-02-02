using System.Diagnostics.Tracing;

namespace LeetCodeSolutions;
public class OddEvenLinkedListSolution
{
    private class ListWrapper
    {
        public ListNode Head;
        public ListNode Tail;

        public void Add(ref ListNode node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.next = node;
                Tail = Tail.next;
            }
        }
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
                evens.Add(ref head);
            }
            else
            {
                odds.Add(ref head);
            }

            head = head.next;
            position++;
        }

        odds.Tail.next = evens.Head;
        evens.Tail.next = null;
        return odds.Head;


    }
}
