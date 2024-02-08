namespace Tests;

using LeetCodeSolutions;
public class LowestCommonAncestorTests
{
  private readonly LowestCommonAncestorSolution _solution;
  public LowestCommonAncestorTests()
  {
    _solution = new();
  }

  [Fact]
  public void Example1()
  {
    TreeNode root = new(3);

    root.left = new(5);
    root.right = new(1);

    root.left.left = new(6);
    root.left.right = new(2);
    root.right.left = new(0);
    root.right.right = new(8);

    root.left.right.left = new(7);
    root.left.right.right = new(4);
    Assert.Equal(root, _solution.LowestCommonAncestor(root, new(5), new(1)));
  }

  [Fact]
  public void Example2()
  {
    TreeNode root = new(3);

    root.left = new(5);
    root.right = new(1);

    root.left.left = new(6);
    root.left.right = new(2);
    root.right.left = new(0);
    root.right.right = new(8);

    root.left.right.left = new(7);
    root.left.right.right = new(4);

    Assert.Equal(root.left, _solution.LowestCommonAncestor(root, new(5), new(4)));
  }

  [Fact]
  public void Example3()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal(root, _solution.LowestCommonAncestor(root, new(1), new(2)));
  }

  [Fact]
  public void BreakingExample1()
  {
    TreeNode root = new(1);
    root.left = new(2);
    root.right = new(3);
    Assert.Equal(root, _solution.LowestCommonAncestor(root, new(2), new(3)));
  }
}
