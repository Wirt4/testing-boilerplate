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
}
