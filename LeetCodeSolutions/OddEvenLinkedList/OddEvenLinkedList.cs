namespace LeetCodeSolutions;
public class OddEvenLinkedListSolution
{
    private class ListWrapper
    {
        public ListNode? Head;
        public ListNode? Tail;

        public void Add(ref ListNode node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            if (Tail != null)
            {
                Tail.next = node;
                Tail = Tail.next;
            }
        }


        public ListNode? Join(ref ListWrapper additionalList)
        {
            if (Tail != null && additionalList.Head != null)
            {
                Tail.next = additionalList.Head;
            }

            if (additionalList.Tail != null)
            {
                additionalList.Tail.next = null;
            }

            return Head;
        }
    }

    private class ListIterator(ListNode head)
    {
        private int position = 1;
        private ListNode current = head;

        public bool PositionIsEven()
        {
            return position % 2 == 0;
        }

        public bool HasRemainingListItems()
        {
            return current != null;
        }

        public void Advance()
        {
            current = current.next;
            position++;
        }

        public ref ListNode CurrentNode => ref current;
    }
    public ListNode OddEvenList(ListNode head)
    {
        ListWrapper evens = new();
        ListWrapper odds = new();
        ListIterator it = new(head);

        while (it.HasRemainingListItems())
        {
            if (it.PositionIsEven())
            {
                evens.Add(ref it.CurrentNode);
            }
            else
            {
                odds.Add(ref it.CurrentNode);
            }
            it.Advance();
        }

        return odds.Join(ref evens);
    }
}
