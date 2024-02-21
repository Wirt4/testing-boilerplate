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

  [Fact]
  public void Example2()
  {
    Assert.Equal(2, _solution.MinReorder(5, [[1, 0], [1, 2], [3, 2], [3, 4]]));
  }
}
