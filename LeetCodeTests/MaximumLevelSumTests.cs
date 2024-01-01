namespace Tests;
using LeetCodeSolutions;
public class MaximumLevelSumTests
{
  private MaximumLevelSumSolution _solution;
  public MaximumLevelSumTests()
  {
    _solution = new();
  }
  [Fact]
  public void MinimumCase1()
  {
    TreeNode root = new(1);
    Assert.Equal(1, _solution.MaxLevelSum(root));
  }

  [Fact]
  public void TwoLevelTree1()
  {
    TreeNode root = new(4);
    root.left = new(8);
    Assert.Equal(2, _solution.MaxLevelSum(root));
  }

  [Fact]
  public void TwoLevelTree2()
  {
    TreeNode root = new(4)
    {
      left = new(8),
      right = new(2)
    };
    Assert.Equal(2, _solution.MaxLevelSum(root));
  }

  [Fact]
  public void Example1()
  {
    TreeNode root = new(1)
    {
      left = new(7),
      right = new(0)
    };
    root.left.left = new(7);
    root.left.right = new(-8);
    Assert.Equal(2, _solution.MaxLevelSum(root));
  }

  [Fact]
  public void Example2()
  {

    TreeNode root = new(989)
    {
      right = new(10250)
    };

    root.right.left = new(98693);
    root.right.right = new(-89388)
    {
      right = new(-32127)
    };

    Assert.Equal(2, _solution.MaxLevelSum(root));
  }

  [Fact]
  public void BreakingCase1()
  {
    TreeNode root = new(1)
    {
      left = new(1),
      right = new(0)
    };

    root.left.left = new(7);
    root.left.right = new(-8);
    root.right.left = new(-7);
    root.right.right = new(9);

    Assert.Equal(1, _solution.MaxLevelSum(root));
  }
}
