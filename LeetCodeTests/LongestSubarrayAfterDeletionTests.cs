namespace Tests;
using LeetCodeSolutions;
public class LongestSubarrayAfterDeletionTests{
    LongestSubarrayAfterDeletion _solution;
    public LongestSubarrayAfterDeletionTests(){
        _solution = new LongestSubarrayAfterDeletion();
    }

    [Fact]
    public void Example1(){
        Assert.Equal(3, _solution.LongestSubarray([1,1,0,1]));
    }
}