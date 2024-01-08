 namespace Tests;
 using LeetCodeSolutions;

 public class StringCompressionTests
{
    [Fact]
    public void Example2(){
        StringCompression solution = new StringCompression();
        char[] arg = ['a'];
        Assert.Equal(1, solution.Compress( arg));
    }

    [Fact]
    public void Example1(){
        StringCompression solution = new StringCompression();
        char [] arg = ['a','a','b','b','c','c','c'];
        Assert.Equal(6, solution.Compress( arg));
    }

    [Fact]
    public void Example3(){
         StringCompression solution = new StringCompression();
         char[] arg = ['a','b','b','b','b','b','b','b','b','b','b','b','b'];
        Assert.Equal(4, solution.Compress( arg));
    }
    [Fact]

    public void FirstFailingTest(){
         StringCompression solution = new StringCompression();
         char [] argument = ['a','a','b','b','c','c','c'];
         Assert.Equal(6, solution.Compress(argument));
       
    }
    
}