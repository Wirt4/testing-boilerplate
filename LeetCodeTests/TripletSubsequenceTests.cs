namespace Tests;
using LeetCodeSolutions;

public class TripletSubsequenceTests{
    [Fact]
    public void sequenceOfOne(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.False(solution.IncreasingTriplet([1]));
    }

    [Fact]
    public void sequenceOfThree(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.True(solution.IncreasingTriplet([1, 2, 3]));
    }
}