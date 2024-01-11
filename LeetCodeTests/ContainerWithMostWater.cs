namespace Tests;

using System.ComponentModel;
using LeetCodeSolutions;

public class ContainerWithMostWaterTests{
    [Fact] 
    public void Example1(){
        WaterContainer solution = new WaterContainer();
        Assert.Equal(49,solution.MaxArea([1,8,6,2,5,4,8,3,7]));
    }

    [Fact] 
    public void Example2(){
        WaterContainer solution = new WaterContainer();
        Assert.Equal(1,solution.MaxArea([1,1]));
    }
}