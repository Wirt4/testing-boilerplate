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


}
