namespace Tests;

using System.Reflection.Metadata.Ecma335;
using LeetCodeSolutions;
public class GuessNumberTests
{
  private GuessNumberSolution _solution;
  public GuessNumberTests()
  {
    _solution = new();
  }
  [Fact]
  public void LCExample1CorrectGuess()
  {
    Func<int, int> guess = CreateGuess(6);

    Assert.Equal(6, _solution.GuessNumber(6));
  }

  [Fact]
  public void LCExample2CorrectGuess()
  {
    Func<int, int> guess = CreateGuess(1);

    Assert.Equal(1, _solution.GuessNumber(1));
  }

  private Func<int, int> CreateGuess(int targetValue)
  {
    Func<int, int> f = (int g) =>
    {
      if (g == targetValue)
      {
        return targetValue;
      }
      if (g > targetValue)
      {
        return -1;
      }

      return 1;
    };

    return f;
  }
}
