namespace Tests;

using Project;
using static Project.Solution;

public class MergeStringsAlternatelyTests
{
    [Fact]
    public void Test1()
    {
        Solution solution = new Solution();
        string result = solution.MergeAlternately("abc", "pqr");

        Assert.Equal("apbqcr", result);
    }

    [Fact]
    public void Test2()
    {
        Solution solution = new Solution();
        string result = solution.MergeAlternately("ab", "pqrs");

        Assert.Equal("apbqrs", result);
    }
    [Fact]
    public void Test3()
    {
        Solution solution = new Solution();
        string result = solution.MergeAlternately("abcd", "pq");

        Assert.Equal("apbqcd", result);
    }
}