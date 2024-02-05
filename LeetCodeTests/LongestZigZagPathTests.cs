namespace Tests;

using LeetCodeSolutions;
public class LongestZigZagPathTests
{
  private LongestZigZagPathSolution _solution;
  public LongestZigZagPathTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    TreeNode root = new(1);

    root.right = new(1);

    root.right.left = new(1);
    root.right.right = new(1);

    root.right.right.left = new(1);
    root.right.right.right = new(1);

    root.right.right.left.right = new(1);

    root.right.right.left.right.right = new(1);

    Assert.Equal(3, _solution.LongestZigZag(root));
  }
  [Fact]
  public void Example3()
  {
    TreeNode root = new(1);
    Assert.Equal(0, _solution.LongestZigZag(root));
  }
}
