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
    public void TOf3(){
        TribonacciNumber solution = new TribonacciNumber();
        Assert.Equal(2, solution.Tribonacci(3));
    }

    [Fact]
    public void TOf4(){
        TribonacciNumber solution = new TribonacciNumber();
        Assert.Equal(4, solution.Tribonacci(4));
    }


    [Fact]
    public void TOf25(){
        TribonacciNumber solution = new TribonacciNumber();
        Assert.Equal(1389537, solution.Tribonacci(25));
    }
    
}