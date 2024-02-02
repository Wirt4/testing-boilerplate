namespace Tests;
using LeetCodeSolutions;
using Tests;
public class ReverseLinkedListTests
{
  private ReverseLinkedListSolution _solution;
  public ReverseLinkedListTests()
  {
    _solution = new();
  }
  [Fact]
  public void ZeroNodes()
  {
    Assert.Null(_solution.ReverseList(null));
  }
  [Fact]
  public void OneNode()
  {
    ListNode node = new(4);
    LinkedListTesting.AssertListsAreEqual(_solution.ReverseList(node), node);
  }
}
