namespace Tests;
using LeetCodeSolutions;

public class CloseStringsTests{
    
    private CloseStringsSolution solution;

public CloseStringsTests(){
        solution = new CloseStringsSolution();
    }

    [Fact]
    public void Example1(){
        Assert.True(solution.CloseStrings("abc", "bca"));
    }

    [Fact]
    public void Example2(){
         Assert.False(solution.CloseStrings("a", "aa"));
    }

    [Fact]
    public void SameLengthStringButFalse(){
        Assert.False(solution.CloseStrings("aabb", "ccdd"));
    }

    [Fact]
    public void Example3(){
        Assert.True(solution.CloseStrings("cabbba", "abbccc"));
    }

    [Fact]
    public void BreakingCase1(){
        Assert.False(solution.CloseStrings("aaabbbbccddeeeeefffff", "aaaaabbcccdddeeeeffff"));
    }

    [Fact]
    public void BreakingCase2(){
        Assert.False(solution.CloseStrings("aabbcccddd", "abccccdddd"));

    }
}
