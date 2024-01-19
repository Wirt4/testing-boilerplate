namespace Tests;
using LeetCodeSolutions;
public class MaximumAverageSubarrayTests{
    [Fact]
    public void Example2(){
        MaximumAverageSubarrayI solution = new MaximumAverageSubarrayI();
        Assert.Equal( 5.00000, solution.FindMaxAverage([5], 1));
    }

    [Fact]
    public void Example1(){
        MaximumAverageSubarrayI solution = new MaximumAverageSubarrayI();
        Assert.Equal( 12.75000, solution.FindMaxAverage([1,12,-5,-6,50,3], 4));
    }

    [Fact]
        public void kIsOne(){
        MaximumAverageSubarrayI solution = new MaximumAverageSubarrayI();
        Assert.Equal( 50.00000, solution.FindMaxAverage([1,12,-5,-6,50,3], 1));
    }

}