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

    [Fact]
    public void TripletsNotContiguous(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.True(solution.IncreasingTriplet([1,1000,3,1000,5]));
    }

     [Fact]

    public void FalseNotStriclyDescending(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.False(solution.IncreasingTriplet([5, 4, 3, 2, 1, 1000]));
    }

    [Fact]

    public void TryToBreakAntithesisOfDescending(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.True(solution.IncreasingTriplet([5, 7, 2, 3, 4]));
    }

    [Fact]

    public void BreakingCase1(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.False(solution.IncreasingTriplet([6,7,1,2]));
    }

     [Fact]

    public void BreakingCase2(){
        TripletSubsequence solution = new TripletSubsequence();
        Assert.True(solution.IncreasingTriplet([1,5,0,4,1,3]));
    }
}