namespace Tests;
using LeetCodeSolutions;

public class MaximumNumberOfVowelsTests{
    [Fact]
    public void Example1(){
        VowelWindow solution = new VowelWindow();
        Assert.Equal(3, solution.MaxVowels("abciiidef", 3));
    }

    [Fact] public void Example2(){
        VowelWindow solution = new VowelWindow();
        Assert.Equal(2, solution.MaxVowels("leetcode", 3));
    }

    [Fact]
    public void NoVowels1(){
        VowelWindow solution = new VowelWindow();
        Assert.Equal(0, solution.MaxVowels("d", 1));
    }
}