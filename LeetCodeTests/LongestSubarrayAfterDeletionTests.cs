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

      [Fact]
    public void Example2(){
        Assert.Equal(5, _solution.LongestSubarray([0,1,1,1,0,1,1,0,1]));
    }

    [Fact]
    public void Example2Modfied(){
        //can't contaenate two subs with one deletion
        Assert.Equal(3, _solution.LongestSubarray([0,1,1,1,0,0,1,1,0,1]));
    }

    [Fact]
    public void NoSuchArray(){
          Assert.Equal(0, _solution.LongestSubarray([0,0,0,0,0,0,0,0,0]));
    }

    [Fact]
    public void Example3(){
         Assert.Equal(2, _solution.LongestSubarray([1,1,1]));
    }
    [Fact]
    public void BreakingCase1(){
         Assert.Equal(2, _solution.LongestSubarray([0,0,1,1]));
    }

    [Fact]
    public void BreakingCase2(){
        Assert.Equal(11, _solution.LongestSubarray([1,0,1,1,1,1,1,1,0,1,1,1,1,1]));
    }
}