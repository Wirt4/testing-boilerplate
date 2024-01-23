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
}