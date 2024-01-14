namespace Tests;
using LeetCodeSolutions;
public class TribonacciTests{
    [Fact]
    public void TOfZero(){
        TribonacciNumber solution = new TribonacciNumber();
        Assert.Equal(0, solution.Tribonacci(0));
    }

    [Fact]
    public void TOfOne(){
        TribonacciNumber solution = new TribonacciNumber();
        Assert.Equal(1, solution.Tribonacci(1));
    }

    [Fact]
    public void TOf25(){
         TribonacciNumber solution = new TribonacciNumber();
        Assert.Equal(1389537, solution.Tribonacci(25));
    }
    
}