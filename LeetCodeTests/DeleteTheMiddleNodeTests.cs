namespace Tests;

using System.Diagnostics.CodeAnalysis;
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
}
