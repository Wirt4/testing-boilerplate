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
  public void Example3()
  {
    TreeNode root = new(1);
    Assert.Equal(0, _solution.LongestZigZag(root));
  }
}
