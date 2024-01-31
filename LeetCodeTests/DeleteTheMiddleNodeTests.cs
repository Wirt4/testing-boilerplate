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
    CompareHeadToDesiredOutput([2, 1], [2]);
  }

  [Fact]
  public void Example3_DifferentValues()
  {
    CompareHeadToDesiredOutput([1, 2], [1]);
  }

  [Fact]
  public void ListOfSize3()
  {
    CompareHeadToDesiredOutput([1, 2, 3], [1, 3]);
  }

  [Fact]

  public void ListOfSize3DifferentData()
  {
    CompareHeadToDesiredOutput([3, 2, 1], [3, 1]);
  }

  [Fact]
  public void Example1()
  {
    CompareHeadToDesiredOutput([1, 3, 4, 7, 1, 2, 6], [1, 3, 4, 1, 2, 6]);
  }

  [Fact]
  public void Example2()
  {
    CompareHeadToDesiredOutput([1, 2, 3, 4], [1, 2, 4]);
  }

  private void CompareHeadToDesiredOutput(int[] head, int[] output)
  {
    ListNode input = ListFromArray(head);
    ListNode desiredOutput = ListFromArray(output);
    ListNode actualOutput = _solution.DeleteMiddle(input);
    AssertListsAreEqual(desiredOutput, actualOutput);
  }

  private void AssertListsAreEqual(ListNode head1, ListNode head2)
  {
    Assert.True(MatchLists(head1, head2));
  }

  private bool MatchLists(ListNode head1, ListNode head2)
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
