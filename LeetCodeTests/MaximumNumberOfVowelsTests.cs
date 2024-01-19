namespace Tests;
using LeetCodeSolutions;

public class MaximumNumberOfVowelsTests{

    VowelWindow _solution;
    public MaximumNumberOfVowelsTests(){
        _solution = new VowelWindow();
    }

    [Fact]
    public void Example1(){
        Assert.Equal(3, _solution.MaxVowels("abciiidef", 3));
    }

    [Fact] public void Example2(){
        Assert.Equal(2, _solution.MaxVowels("leetcode", 3));
    }

    [Fact]
    public void NoVowels1(){
        Assert.Equal(0, _solution.MaxVowels("d", 1));
    }
}