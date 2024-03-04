namespace Tests;
using LeetCodeSolutions;
public class UniquePathsTests
{
  private UniquePathsSolution _solution;
  public UniquePathsTests()
  {
    _solution = new();
  }
  [Fact]
  public void GridOfOne()
  {
    int m = 1;
    int n = 1;
    int expected = 1;
    int acutal = _solution.UniquePaths(m, n);
    Assert.Equal(expected, acutal);
  }
  [Fact]
  public void LCExample1()
  {
    int m = 3;
    int n = 7;
    int expected = 28;
    int acutal = _solution.UniquePaths(m, n);
    Assert.Equal(expected, acutal);
  }
}
