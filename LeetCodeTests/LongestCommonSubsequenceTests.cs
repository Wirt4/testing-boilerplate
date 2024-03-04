namespace Tests;
using LeetCodeSolutions;
public class LongestCommonSubsequenceTests
{
  private LongestCommonSubsequenceSolution _solution;
  public LongestCommonSubsequenceTests()
  {
    _solution = new();
  }
  [Fact]
  public void TextLengthsOfOne1()
  {
    Assert.Equal(1, _solution.LongestCommonSubsequence("a", "a"));
  }
  [Fact]
  public void TextLengthsOfOne2()
  {
    Assert.Equal(0, _solution.LongestCommonSubsequence("a", "b"));
  }

  [Fact]
  public void TextLengthsOfTwo1()
  {
    Assert.Equal(2, _solution.LongestCommonSubsequence("fh", "fh"));
  }
  [Fact]
  public void TextLengthsOfTwo2()
  {
    Assert.Equal(1, _solution.LongestCommonSubsequence("fh", "fg"));
  }
}
