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
}