namespace Tests;
using LeetCodeSolutions;
public class SearchInBinaryTreeTests
{
  private SearchInBinaryTreeSolution _solution;
  public SearchInBinaryTreeTests()
  {
    _solution = new();
  }
  [Fact]
  public void ValueNotInTree()
  {
    TreeNode root = new(2);
    Assert.Null(_solution.SearchBST(root, 1));
  }
}
