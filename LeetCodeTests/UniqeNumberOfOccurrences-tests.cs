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
}