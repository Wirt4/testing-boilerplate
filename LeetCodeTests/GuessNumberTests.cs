namespace Tests;
using LeetCodeSolutions;
public class GuessNumberTests
{
  private GuessNumberSolution _solution;
  public GuessNumberTests()
  {
    _solution = new();
  }
  [Fact]
  public void LCExample1()
  {
    int guess(int g)
    {
      if (g == 6)
      {
        return 6;
      }
      if (g > 6)
      {
        return -1;
      }
      return 1;
    }

    Assert.Equal(6, _solution.GuessNumber(6));
  }
}
