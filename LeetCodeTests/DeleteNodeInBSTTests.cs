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

  [Fact]
  public void OneDTreeOfTwo()
  {
    TreeNode root = new(1);
    root.left = new(4);
    Assert.True(EqualTrees(new TreeNode(1), _solution.DeleteNode(root, 4)));
  }

  private bool EqualTrees(TreeNode? root1, TreeNode? root2)
  {
    if (root1 == null && root2 == null)
    {
      return true;
    }

    if (root1 == null || root2 == null || root1.val != root2.val)
    {
      return false;
    }
    return EqualTrees(root1.left, root2.left) && EqualTrees(root1.right, root2.right);
  }
}
