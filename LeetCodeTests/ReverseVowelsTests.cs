namespace Tests;

using LeetCodeSolutions;

public class ReverseVowelsTests{
    [Fact]
    public void Example1(){
        Vowels solution = new Vowels();
        Assert.Equal("holle", solution.ReverseVowels("hello"));
    }
}