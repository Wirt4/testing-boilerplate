 namespace Tests;
 using LeetCodeSolutions;

 public class StringCompressionTests
{
    [Fact]
    public void Example2(){
        StringCompression solution = new StringCompression();
        char[] arg = ['a'];
        Assert.Equal(1, solution.Compress(arg));
    }

     [Fact]
    public void Example2Guts(){
        StringCompression solution = new StringCompression();
        char[] arg = ['a'];
        solution.CompressString(ref arg);
        Assert.Equal(['a'], arg);
    }

    [Fact]
    public void Example1(){
        StringCompression solution = new StringCompression();
        char [] arg = ['a','a','b','b','c','c','c'];
        Assert.Equal(6, solution.Compress( arg));
    }

     [Fact]
    public void Example1Guts(){
        StringCompression solution = new StringCompression();
        char [] arg = ['a','a','b','b','c','c','c'];
         solution.CompressString(ref arg);
        Assert.Equal(['a', '2', 'b', '2', 'c', '3'], arg);
    }

    [Fact]
    public void Example3(){
        StringCompression solution = new StringCompression();
        char[] arg = ['a','b','b','b','b','b','b','b','b','b','b','b','b'];
        Assert.Equal(4, solution.Compress( arg));
    }

     [Fact]
    public void Example3Guts(){
        StringCompression solution = new StringCompression();
        char[] arg = ['a','b','b','b','b','b','b','b','b','b','b','b','b'];
        solution.CompressString(ref arg);
        Assert.Equal(['a', 'b', '1', '2'], arg);
    }

    [Fact]
    public void FirstFailingTest(){
         StringCompression solution = new StringCompression();
         char [] argument = ['a','a','b','b','c','c','c'];
         Assert.Equal(6, solution.Compress(argument));
       
    }

      [Fact]
    public void SecondFailingTest(){
         StringCompression solution = new StringCompression();
         char [] argument = ['a','a','a','b','b','a','a'];
        solution.CompressString(ref argument);
        Assert.Equal(['a', '3', 'b', '2', 'a', '2'], argument);
       
    }

    [Fact]
     public void ThirdFailingTest(){
         StringCompression solution = new StringCompression();
         char [] argument = ['a', 'b', 'c'];
        solution.CompressString(ref argument);
        Assert.Equal(['a','b', 'c'], argument);
       
    }
    
}