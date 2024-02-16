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

  [Fact]
  public void ValueInTree()
  {
    TreeNode root = new(2);
    Assert.Equal(root, _solution.SearchBST(root, 2));
  }

  [Fact]
  public void ValueInTreeCase2()
  {
    TreeNode root = new(4);
    Assert.Equal(root, _solution.SearchBST(root, 4));
  }

  [Fact]
  public void ValueInLeftNode()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal(root.left, _solution.SearchBST(root, 2));
  }


}
