namespace Tests;
using LeetCodeSolutions;
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class LinkedListTesting
{

    public static ListNode ListFromArray(int[] arr)
    {
        ListNode head = new(arr[0]);
        ListNode cur = head;
        for (int i = 1; i < arr.Length; i++)
        {
            cur.next = new(arr[i]);
            cur = cur.next;
        }

        return head;
    }
    public static void AssertListsAreEqual(ListNode head1, ListNode head2)
    {
        Assert.True(MatchLists(head1, head2));
    }

    private static bool MatchLists(ListNode head1, ListNode head2)
    {
        if (head1 == null && head2 == null)
        {
            return true;
        }

        if (head1 == null || head2 == null)
        {
            return false;
        }

        if (head1.val == head2.val)
        {
            return MatchLists(head1.next, head2.next);
        }

        return false;
    }

}