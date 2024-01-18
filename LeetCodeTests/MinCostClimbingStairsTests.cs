namespace Tests;
using LeetCodeSolutions;
public class MinCostClimbingStairsTests{

private Stairs _solution;
    public MinCostClimbingStairsTests(){
        _solution = new Stairs();
    }

    [Fact]
    public void ArrayOfTwoBothAreZero(){
        Assert.Equal(0, _solution.MinCostClimbingStairs([0,0]));
    }
}