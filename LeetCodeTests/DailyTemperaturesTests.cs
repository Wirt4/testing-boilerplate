using LeetCodeSolutions;

namespace Tests;

public class DailyTemperaturesTests{
    [Fact]
    public void Example1(){
        Temperatures solution = new Temperatures();
        Assert.Equal([1,1,4,2,1,1,0,0], solution.DailyTemperatures([73,74,75,71,69,72,76,73]));
    }

     [Fact]
    public void Example2(){
        Temperatures solution = new Temperatures();
        Assert.Equal([1,1,1,0], solution.DailyTemperatures([30,40,50,60]));
    }

    [Fact]
    public void BreakingCase1(){
        Temperatures solution = new Temperatures();
        Assert.Equal([1,0,0,0,1,0,0,0,0,0], solution.DailyTemperatures([34,80,80,80,34,80,80,80,34,34]));
    }
}