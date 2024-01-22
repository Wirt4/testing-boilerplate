namespace Tests;
using LeetCodeSolutions;
public class FindPivotIndexTests{
    private PivotSolution solution;
    public FindPivotIndexTests(){
        solution = new PivotSolution();
    }
    [Fact]
    public void NumsLengthOfOne(){
        Assert.Equal(0,solution.PivotIndex([2]));
    }

    [Fact]
    public void Example1(){
        Assert.Equal(3, solution.PivotIndex([1,7,3,6,5,6]));
    }

    [Fact]
    public void Example3(){
        Assert.Equal(-1, solution.PivotIndex([1,2,3]));
    }
}