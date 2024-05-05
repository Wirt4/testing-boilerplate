namespace Tests;
using LeetCodeSolutions;
public class UniqueNumberOfOccurencesTests{
    private UniqueNumberOfOccurencesSolution solution;
    public UniqueNumberOfOccurencesTests(){
        solution = new UniqueNumberOfOccurencesSolution();
    }

    [Fact]
    public void Example1(){
        Assert.True(solution.UniqueOccurrences([1,2,2,1,1,3]));
    }

    [Fact]
    public void Example2(){
        Assert.False(solution.UniqueOccurrences([1,2]));
    }

    [Fact]
     public void Example3(){
        Assert.True(solution.UniqueOccurrences([-3,0,1,-3,1,1,1,-3,10,0]));
    }
}