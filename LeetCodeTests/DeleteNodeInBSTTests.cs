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
    Stack<TreeNode> stack1 = new();
    Stack<TreeNode> stack2 = new();
    if (root1 != null) stack1.Push(root1);
    if (root2 != null) stack2.Push(root2);

    while (stack1.Count > 0 && stack2.Count > 0)
    {


      if (stack1.TryPop(out TreeNode node1) && stack2.TryPop(out TreeNode node2))
      {
        if (node1.val != node2.val)
        {
          return false;
        }
      }
      else if (stack1.Count > 0 || stack2.Count > 0)
      {
        return false;
      }

    }

    return true;
  }
}
