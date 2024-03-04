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
  public void TextLengthsOfOne()
  {
    Assert.Equal(1, _solution.LongestCommonSubsequence("a", "a"));
  }
}
