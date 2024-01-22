using LeetCodeSolutions;

namespace Tests;

public class FindTheDifferenceOfTwoArraysTests{
    private FindTheDifferenceOfTwoArraysSolution solution;
    public FindTheDifferenceOfTwoArraysTests(){
        solution = new FindTheDifferenceOfTwoArraysSolution();
    }
    [Fact]
    public void Example1(){
        Assert.Equal([[1,3],[4,6]], solution.FindDifference([1,2,3], [2,4,6]));
    }

    [Fact]
    public void Example2(){
         Assert.Equal([[3],[]], solution.FindDifference([1,2,3,3], [1,1,2,2]));
    }
}