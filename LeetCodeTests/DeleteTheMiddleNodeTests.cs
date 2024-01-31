namespace Tests;

using LeetCodeSolutions;
public class DeleteTheMiddleNodeTests
{
  private DeleteTheMiddleNodeSolution _solution;
  public DeleteTheMiddleNodeTests()
  {
    _solution = new();
  }
  [Fact]
  public void LinkedListOfSizeOne()
  {
    ListNode head = new();
    Assert.Null(_solution.DeleteMiddle(head));
  }

  [Fact]
  public void Example3()
  {
    /**
    Input: head = [2,1]
    Output: [2]
    */

    ListNode Tail = new(1);
    ListNode InputHead = new(2, Tail);

    ListNode Output = _solution.DeleteMiddle(InputHead);
    Assert.Equal(2, Output.val);
    Assert.Null(Output.next);
  }

  [Fact]
  public void Example3_DifferentValues()
  {
    /**
    Input: head = [1,2]
    Output: [1]
    */

    ListNode Tail = new(2);
    ListNode InputHead = new(1, Tail);

    ListNode Output = _solution.DeleteMiddle(InputHead);
    Assert.Equal(1, Output.val);
    Assert.Null(Output.next);
  }

  [Fact]
  public void ListOfSize3()
  {
    /**
    Input: head = [1,2,3]
    Output: [1,3]
    */
    ListNode head = ListFromArray([1, 2, 3]);
    Assert.True(AssertListsAreEqual(ListFromArray([1, 3]), _solution.DeleteMiddle(head)));
  }

  private bool AssertListsAreEqual(ListNode head1, ListNode head2)
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
      return AssertListsAreEqual(head1.next, head2.next);
    }

    return false;
  }

  private static ListNode ListFromArray(int[] arr)
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
}
