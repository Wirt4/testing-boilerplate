namespace Tests;
using LeetCodeSolutions;
public class TribonacciTests{
    private TribonacciNumber _solution;
    public TribonacciTests(){
        _solution = new TribonacciNumber();
    }
    [Fact]
    public void TOfZero(){
        Assert.Equal(0, _solution.Tribonacci(0));
    }

    [Fact]
    public void TOfOne(){
        Assert.Equal(1, _solution.Tribonacci(1));
    }

    [Fact]
    public void TOf3(){
        Assert.Equal(2, _solution.Tribonacci(3));
    }

    [Fact]
    public void TOf4(){
        Assert.Equal(4, _solution.Tribonacci(4));
    }


    [Fact]
    public void TOf25(){
        Assert.Equal(1389537, _solution.Tribonacci(25));
    }
    
}