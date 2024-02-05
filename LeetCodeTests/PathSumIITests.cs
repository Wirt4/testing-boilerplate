namespace Tests;
using LeetCodeSolutions;
public class PathSumIITests
{
  private PathSumIISolution _solution;
  public PathSumIITests()
  {
    _solution = new();
  }
  [Fact]
  public void Example3()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal([], _solution.PathSum(root, 0));
  }

  [Fact]
  public void Example3DifferentTarget()
  {
    TreeNode root = new(1);
    root.left = new(2);
    Assert.Equal([[1, 2]], _solution.PathSum(root, 3));
  }

  [Fact]
  public void Example1()
  {
    TreeNode root = new(5);
    root.left = new(4);
    root.right = new(8);

    root.left.left = new(11);
    root.right.left = new(13);
    root.right.right = new(4);

    root.left.left.left = new(7);
    root.left.left.right = new(2);
    root.right.right.left = new(5);
    root.right.right.right = new(1);


    ; Assert.Equal([[5, 4, 11, 2], [5, 8, 4, 5]], _solution.PathSum(root, 22));
  }
}
