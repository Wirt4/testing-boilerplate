 namespace Tests;
 using LeetCodeSolutions;

 public class StringCompressionTests
{
    [Fact]
    public void inputOfLengthOne(){
        StringCompression solution = new StringCompression();
        Assert.Equal(1, solution.Compress(['a']));
    }

    [Fact]
    public void Example1(){
        StringCompression solution = new StringCompression();
        Assert.Equal(6, solution.Compress(['a','a','b','b','c','c','c']));
    }
    
}