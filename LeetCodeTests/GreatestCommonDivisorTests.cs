namespace Tests;

using LeetCodeSolutions;
using static LeetCodeSolutions.GreatestCommonDivisor;

public class GreatestCommonDivisorTests
{
    [Fact]
    public void Test1()
    {
        GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("ABCABC", "ABC");

        Assert.Equal("ABC", result);
    }

    [Fact]
    public void Test2()
    {
        GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("LEET", "CODE");

        Assert.Equal("", result);
    }

}