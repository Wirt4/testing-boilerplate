namespace Tests;
using LeetCodeSolutions;

public class MaximumNumberOfVowelsTests{
    [Fact]
    public void example1(){
        VowelWindow solution = new VowelWindow();
        Assert.Equal(3, solution.MaxVowels("abciiidef", 3));
    }
    [Fact]
    public void noVowels1(){
        VowelWindow solution = new VowelWindow();
        Assert.Equal(0, solution.MaxVowels("d", 1));
    }
}