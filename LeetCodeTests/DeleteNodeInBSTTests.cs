namespace Tests;
using LeetCodeSolutions;
public class DeleteNodeInBSTTests
{
  private DeleteNodeInBSTSolution _solution;
  public DeleteNodeInBSTTests()
  {
    _solution = new();
  }
  [Fact]
  public void TreeOfOne1()
  {
    TreeNode root = new(1);
    Assert.Equal(root, _solution.DeleteNode(root, 49));
  }
}
