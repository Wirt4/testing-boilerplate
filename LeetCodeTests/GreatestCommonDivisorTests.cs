namespace Tests;

using LeetCodeSolutions;
using static LeetCodeSolutions.GreatestCommonDivisor;

public class GreatestCommonDivisorTests
{
    [Fact]
    public void StringTwoIsDivisorOfStringOne()
    {
        GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("ABCABC", "ABC");

        Assert.Equal("ABC", result);
    }

    [Fact]
    public void CompleteMisMatchStrings()
    {
        GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("LEET", "CODE");

        Assert.Equal("", result);
    }

    [Fact]
    public void CommonDivisorIsSubstringOfString2()
    {
    GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("ABABAB", "ABAB");

        Assert.Equal("AB", result);
    }

    [Fact]
    public void StringOneIsShorterI()
    {
        GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("ABC", "ABCABC");

        Assert.Equal("ABC", result);
    }

    [Fact]
    public void StringOneIsShoterII()
    {
    GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("ABAB", "ABABAB");

        Assert.Equal("AB", result);
    }

    [Fact]
     public void OneCharacterOff()
    {
    GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("ABABAB", "ABAF");

        Assert.Equal("", result);
    }

     [Fact]
     public void OneCharacterOffButRemainderWorks()
    {
    GreatestCommonDivisor solution = new GreatestCommonDivisor();
        string result = solution.GcdOfStrings("ABABABAB", "ABAF");

        Assert.Equal("", result);
    }

}