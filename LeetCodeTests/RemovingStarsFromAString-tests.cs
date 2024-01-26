namespace Tests;
using LeetCodeSolutions;

public class RemovingStarsFromAStringTests{
    private readonly RemovingStarsFromAStringSolution solution;
    public RemovingStarsFromAStringTests(){
        solution = new RemovingStarsFromAStringSolution();
    }

    [Fact]
    public void Example1(){
        Assert.Equal("lecoe", solution.RemoveStars("leet**cod*e"));
    }

    [Fact]
    public void Example2(){
        Assert.Equal("", solution.RemoveStars("erase*****"));
    }
}