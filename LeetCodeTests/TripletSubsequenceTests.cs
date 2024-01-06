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

    [Fact]
    public void Example1(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.True(solution.IncreasingTriplet([1,2,3,4,5]));
    }

    [Fact]

    public void Example2(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.False(solution.IncreasingTriplet([5, 4, 3, 2, 1]));
    }
}