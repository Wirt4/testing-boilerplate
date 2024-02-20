namespace Tests;
using LeetCodeSolutions;
public class ReorderRoutesToLeadToZeroTests
{
  private ReorderRoutesToLeadToZeroSolution _solution;
  public ReorderRoutesToLeadToZeroTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    Assert.Equal(3, _solution.MinReorder(6, [[0, 1], [1, 3], [2, 3], [4, 0], [4, 5]]));
  }
}
