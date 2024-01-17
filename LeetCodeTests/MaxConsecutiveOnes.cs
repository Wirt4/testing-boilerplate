using LeetCodeSolutions;

namespace Tests;

public class MaxConsecutiveOnesIIITests{
    private MaxConsecutiveOnes _maxOnes;
    public MaxConsecutiveOnesIIITests(){
        _maxOnes = new MaxConsecutiveOnes();
    }
    [Fact]
    public void LengthOneKIsZero(){
        Assert.Equal(0, _maxOnes.LongestOnes([0],0));
    }

     [Fact]
    public void LengthOneAllOnes(){
        Assert.Equal(1, _maxOnes.LongestOnes([1],0));
    }

    [Fact]
    public void Example1(){
            Assert.Equal(6, _maxOnes.LongestOnes([1,1,1,0,0,0,1,1,1,1,0],2));
    }

    [Fact]
    public void Example2(){
            Assert.Equal(10, _maxOnes.LongestOnes([0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1],3));
    }
}