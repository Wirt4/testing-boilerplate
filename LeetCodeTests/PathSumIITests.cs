namespace Tests;
using LeetCodeSolutions;
public class PathSumIITests
{
  private PathSumIISolution _solution;
  public PathSumIITests()
  {
    _solution = new();
  }
  [Fact]
  public void Example3()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal([], _solution.PathSum(root, 0));
  }

  [Fact]
  public void Example3DifferentTarget()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal([[1, 2]], _solution.PathSum(root, 3));
  }
}
