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

    [Fact]
    public void Example1 (){
        Assert.Equal(15, _solution.MinCostClimbingStairs([10,15,20]));
    }

    [Fact]
    public void ArrayOfTwoStartOnIndexOne(){
        Assert.Equal(0, _solution.MinCostClimbingStairs([10,0]));
    }
}