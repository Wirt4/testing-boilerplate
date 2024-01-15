namespace Tests;
using LeetCodeSolutions;
public class MaximumAverageSubarrayTests{
    [Fact]
    public void Example2(){
        MaximumAverageSubarrayI solution = new MaximumAverageSubarrayI();
        Assert.Equal( 5.00000, solution.FindMaxAverage([5], 1));
    }
}