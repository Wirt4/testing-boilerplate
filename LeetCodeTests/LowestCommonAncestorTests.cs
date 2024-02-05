namespace Tests;
using LeetCodeSolutions;
public class LowestCommonAncestorTests
{
  private LowestCommonAncestorSolution _solution;
  public LowestCommonAncestorTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example3()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal(root, _solution.LowestCommonAncestor(root, new(1), new(2)));
  }
}
