namespace Tests;
using LeetCodeSolutions;
public class MaximumLevelSumTests
{
  private MaximumLevelSumSolution _solution;
  public MaximumLevelSumTests()
  {
    _solution = new();
  }
  [Fact]
  public void MinimumCase1()
  {
    TreeNode root = new(1);
    Assert.Equal(1, _solution.MaxLevelSum(root));
  }
}
