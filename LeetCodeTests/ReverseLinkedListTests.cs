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
    Compare([1, 2], [2, 1]);
  }

  private void Compare(int[] input, int[] expected)
  {
    ListNode argument = LinkedListTesting.ListFromArray(input);
    ListNode expectedAnswer = LinkedListTesting.ListFromArray(expected);
    LinkedListTesting.AssertListsAreEqual(_solution.ReverseList(argument), expectedAnswer);
  }
}
