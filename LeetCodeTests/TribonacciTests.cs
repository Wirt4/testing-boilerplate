namespace Tests;
using LeetCodeSolutions;
public class TribonacciTests{
    [Fact]
    public void TOfZero(){
        TribonacciNumber solution = new TribonacciNumber();
        Assert.Equal(0, solution.Tribonacci(0));
    }
    
}