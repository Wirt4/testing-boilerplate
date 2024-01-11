namespace Tests;
using LeetCodeSolutions;

public class IsSubsequenceTests{
    [Fact]
    public void subsequenceShrugged(){
        Subsequence soultion = new Subsequence();
        Assert.True(soultion.IsSubsequence("a", "a"));
    }

    [Fact]
    public void Example2(){
        Subsequence soultion = new Subsequence();
        Assert.False(soultion.IsSubsequence("axc", "ahbgdc"));
    }
    [Fact]
    public void Example1(){
        Subsequence soultion = new Subsequence();
        Assert.True(soultion.IsSubsequence("abc", "ahbgdc"));
    }
    [Fact]
    public void EmptyString1(){
        Subsequence soultion = new Subsequence();
        Assert.True(soultion.IsSubsequence("", ""));
    }

    [Fact]
    public void BreakingCaseForRefactor1(){
         Subsequence soultion = new Subsequence();
        Assert.False(soultion.IsSubsequence("acb", "ahbgdc"));
    }

     [Fact]
    public void BreakingCaseForRefactor2(){
        Subsequence soultion = new Subsequence();
        Assert.False(soultion.IsSubsequence("aaaaaa", "bbaaaa"));
    }
}