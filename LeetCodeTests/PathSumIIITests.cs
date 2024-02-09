namespace Tests;
using LeetCodeSolutions;
public class PathSumIIITests
{
    private PathSumIIISolution _solution;
    public PathSumIIITests()
    {
        _solution = new();
    }

    [Fact]
    public void EmptyTree()
    {
        Assert.Equal(0, _solution.PathSum(null, 0));
    }

    [Fact]
    public void TreeOfOne()
    {
        TreeNode root = new(4);
        Assert.Equal(1, _solution.PathSum(root, 4));
    }

    [Fact]
    public void Example1()
    {
        TreeNode root = new TreeNode(10);

        root.left = new(5);
        root.right = new TreeNode(-3);

        root.left.left = new(3);
        root.left.right = new(2);
        root.right.right = new(11);

        root.left.left.left = new(3);
        root.left.left.right = new(-2);
        root.left.right.right = new(1);

        Assert.Equal(3, _solution.PathSum(root, 8));
    }

    [Fact]
    public void BreakingTest1()
    {
        TreeNode root = new(1000000000);

        root.left = new(1000000000);
        root.left.left = new(294967296);
        root.left.left.left = new(1000000000);
        root.left.left.left.left = new(1000000000);
        root.left.left.left.left.left = new(1000000000);

        Assert.Equal(0, _solution.PathSum(root, 0));
    }

}
