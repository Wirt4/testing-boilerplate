namespace Tests;

using LeetCodeSolutions;

public class ReverseWordsTests{
    [Fact]
    public void oneWord(){
        ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("hello", rWords.ReverseWords("hello"));
    }
}