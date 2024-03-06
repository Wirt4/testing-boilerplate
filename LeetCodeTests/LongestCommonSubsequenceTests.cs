namespace Tests;
using LeetCodeSolutions;
public class LongestCommonSubsequenceTests
{
  public LongestCommonSubsequenceTests()
  {

  }

  private class Parameters
  {

    public Parameters(string text1, string text2)
    {
      this.text1 = text1;
      this.text2 = text2;
      _solution = new();
    }
    private string text1;
    private LongestCommonSubsequenceSolution _solution;
    public string text2;
    public void AssertLongestCommonSubsequenceIs(int expectedAnswer)
    {
      int result = _solution.LongestCommonSubsequence(text1, text2);
      Assert.Equal(expectedAnswer, result);
    }
  }


  [Fact]
  public void TextLengthsOfOne1()
  {
    Parameters parameters = new("a", "a");
    parameters.AssertLongestCommonSubsequenceIs(1);
  }

  [Fact]
  public void TextLengthsOfOne2()
  {
    Parameters parameters = new("a", "b");
    parameters.AssertLongestCommonSubsequenceIs(0);
  }

  [Fact]
  public void TextLengthsOfTwo1()
  {
    Parameters parameters = new("fh", "fh");
    parameters.AssertLongestCommonSubsequenceIs(2);
  }
  [Fact]
  public void TextLengthsOfTwo2()
  {
    Parameters parameters = new("fh", "fg");
    parameters.AssertLongestCommonSubsequenceIs(1);
  }

  [Fact]
  public void LCExample1()
  {
    Parameters parameters = new("abcde", "ace");
    parameters.AssertLongestCommonSubsequenceIs(3);
  }

  [Fact]
  public void LCExample2()
  {
    Parameters parameters = new("abc", "abc");
    parameters.AssertLongestCommonSubsequenceIs(3);
  }


  [Fact]
  public void LCExample0()
  {
    Parameters parameters = new("abc", "def");
    parameters.AssertLongestCommonSubsequenceIs(0);
  }
}
