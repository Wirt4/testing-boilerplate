namespace Tests;
using LeetCodeSolutions;

public class IsSubsequenceTests{
    [Fact]
    public void subsequenceShrugged(){
        Subsequence soultion = new Subsequence();
        Assert.True(soultion.IsSubsequence("a", "a"));
    }
}