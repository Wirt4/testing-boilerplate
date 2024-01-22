using LeetCodeSolutions;

namespace Tests;

public class FindTheDifferenceOfTwoArraysTests{
    [Fact]
    public void Example1(){
        FindTheDifferenceOfTwoArraysSolution  solution = new FindTheDifferenceOfTwoArraysSolution();
        Assert.Equal([[1,3],[4,6]], solution.FindDifference([1,2,3], [2,4,6]));
    }
}