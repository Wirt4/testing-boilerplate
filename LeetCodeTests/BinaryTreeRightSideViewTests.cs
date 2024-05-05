namespace Tests;

using System.Security.Cryptography;
using LeetCodeSolutions;
public class BinaryTreeRightSideViewTests
{
  private BinaryTreeRightSideViewSolution _solution;
  public BinaryTreeRightSideViewTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    TreeNode root = new(1);

    root.left = new(2);
    root.right = new TreeNode(3);

    root.left.right = new(5);
    root.right.right = new(4);

    Assert.Equal([1, 3, 4], _solution.RightSideView(root));
  }
  [Fact]
  public void Example2()
  {
    TreeNode root = new(1)
    {
      right = new(3)
    };
    Assert.Equal([1, 3], _solution.RightSideView(root));
  }
  [Fact]
  public void Example3()
  {
    Assert.Equal([], _solution.RightSideView(null));
  }

  [Fact]
  public void BreakingCase1()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal([1, 2], _solution.RightSideView(root));
  }
}
