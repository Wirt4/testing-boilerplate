using LeetCodeSolutions;

namespace Tests;

public class DailyTemperaturesTests{
    [Fact]
    public void Example1(){
        Temperatures solution = new Temperatures();
        Assert.Equal([1,1,4,2,1,1,0,0], solution.DailyTemperatures([73,74,75,71,69,72,76,73]));
    }
}