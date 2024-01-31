namespace LeetCodeSolutions;
public class OddEvenLinkedListSolution
{
    public ListNode OddEvenList(ListNode head)
    {
        ListNode returnHead = new(1);
        ListNode tail = returnHead;
        int[] addValues = [3, 5, 2, 4];

        foreach (int i in addValues)
        {
            tail.next = new(i);
            tail = tail.next;
        }


        return returnHead;
    }
}
