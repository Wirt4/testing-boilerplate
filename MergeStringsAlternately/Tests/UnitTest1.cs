namespace Tests;

using Project;
using static Project.Solution;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Solution solution = new Solution();
        string result = solution.MergeAlternately("abc", "pqr");

        Assert.Equal("apbqcr", result);
    }
}