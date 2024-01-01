namespace Tests;

using LeetCodeSolutions;

public class ReverseWordsTests{
    [Fact]
    public void oneWord(){
        ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("hello", rWords.ReverseWords("hello"));
    }

    [Fact]
    public void oneWord2(){
        ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("goodbye", rWords.ReverseWords("goodbye"));
    }

    [Fact]
    public void twoWords(){
        ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("boingo oingo", rWords.ReverseWords("oingo boingo"));
    }

    [Fact]
    public void oneWordExtraSpaces(){
         ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("music", rWords.ReverseWords("    music "));
    }

     [Fact]
     public void twoWordsExtraSpaces(){
        ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("music great", rWords.ReverseWords(" great   music "));
    }
}