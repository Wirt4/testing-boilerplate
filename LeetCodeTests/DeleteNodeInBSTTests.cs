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
    Assert.True(EqualTrees(root, _solution.DeleteNode(root, 49)));
  }

  [Fact]
  public void OneDTreeOfTwo1()
  {
    TreeNode root = new(1);
    root.left = new(4);
    TreeNode ans = new(1);
    Assert.True(EqualTrees(ans, _solution.DeleteNode(root, 4)));
  }

  [Fact]
  public void OneDTreeOfTwoNoMatch()
  {
    TreeNode root = new(1)
    {
      right = new(6)
    };
    TreeNode ans = new(1)
    {
      right = new(6)
    };
    Assert.True(EqualTrees(ans, _solution.DeleteNode(root, 4)));
  }

  [Fact]
  private void Example1()
  {
    TreeNode input = new(5);

    input.left = new(3);
    input.right = new(6);

    input.left.left = new(2);
    input.left.right = new(4);

    input.right.right = new(7);

    TreeNode output = new(5);
    output.left = new(4);
    output.right = new(6);
    output.left.left = new(2);
    output.right.right = new(7);

    Assert.True(EqualTrees(output, _solution.DeleteNode(input, 3)));
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
