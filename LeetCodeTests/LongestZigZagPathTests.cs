namespace Tests;

using LeetCodeSolutions;
public class LongestZigZagPathTests
{
  private LongestZigZagPathSolution _solution;
  public LongestZigZagPathTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    TreeNode root = new(1);

    root.right = new(1);

    root.right.left = new(1);
    root.right.right = new(1);

    root.right.right.left = new(1);
    root.right.right.right = new(1);

    root.right.right.left.right = new(1);

    root.right.right.left.right.right = new(1);

    Assert.Equal(3, _solution.LongestZigZag(root));
  }

  [Fact]
  public void Example2()
  {
    TreeNode root = new(1);

    root.left = new(1);
    root.right = new(1);

    root.left.right = new(1);

    root.left.right.left = new(1);
    root.left.right.right = new(1);

    root.left.right.left.right = new(1);
    Assert.Equal(4, _solution.LongestZigZag(root));

  }

  [Fact]
  public void Example3()
  {
    TreeNode root = new(1);
    Assert.Equal(0, _solution.LongestZigZag(root));
  }

  [Fact]
  public void LengthOfOneRightSide()
  {
    TreeNode root = new(1);
    root.right = new(1);
    Assert.Equal(1, _solution.LongestZigZag(root));
  }

  [Fact]

  public void LengthOfNullReference()
  {
    Assert.Equal(0, _solution.LongestZigZag(null));
  }

  [Fact]
  public void LengthOfTwoLeft()
  {
    TreeNode root = new(1);
    root.left = new(1);
    root.left.right = new(1);
    Assert.Equal(2, _solution.LongestZigZag(root));
  }

  [Fact]
  public void LengthOfTwoRight()
  {
    TreeNode root = new(1);
    root.right = new(1);
    root.right.left = new(1);
    Assert.Equal(2, _solution.LongestZigZag(root));
  }
}
