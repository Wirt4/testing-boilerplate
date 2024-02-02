namespace Tests;
using LeetCodeSolutions;
using Microsoft.VisualBasic;
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

  [Fact]
  public void Example2()
  {
    ListNode input = LinkedListTesting.ListFromArray([1, 2]);
    ListNode expectedAnswer = LinkedListTesting.ListFromArray([2, 1]);
    LinkedListTesting.AssertListsAreEqual(_solution.ReverseList(input), expectedAnswer);
  }
}
