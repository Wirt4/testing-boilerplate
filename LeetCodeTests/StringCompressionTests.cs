 namespace Tests;
 using LeetCodeSolutions;

 public class StringCompressionTests
{
    [Fact]
    public void inputOfLengthOne(){
        StringCompression solution = new StringCompression();
        Assert.Equal(2, solution.Compress(['a']));
    }
    
}