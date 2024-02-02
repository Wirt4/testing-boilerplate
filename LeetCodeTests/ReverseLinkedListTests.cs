namespace Tests;
using LeetCodeSolutions;
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
}
