namespace Tests;

using Project;
using static Project.MergeAlternatively;

public class MergeStringsAlternatelyTests
{
    [Fact]
    public void Test1()
    {
        MergeAlternatively solution = new MergeAlternatively();
        string result = solution.MergeAlternately("abc", "pqr");

        Assert.Equal("apbqcr", result);
    }

    [Fact]
    public void Test2()
    {
        MergeAlternatively solution = new MergeAlternatively();
        string result = solution.MergeAlternately("ab", "pqrs");

        Assert.Equal("apbqrs", result);
    }
    [Fact]
    public void Test3()
    {
        MergeAlternatively solution = new MergeAlternatively();
        string result = solution.MergeAlternately("abcd", "pq");

        Assert.Equal("apbqcd", result);
    }
}