namespace Tests;

using System.ComponentModel.Design;
using LeetCodeSolutions;
public class KokoEatsBananasTests
{
  private KokoEatsBananasSolution _solution;
  public KokoEatsBananasTests()
  {
    _solution = new();
  }

  private class Parameters
  {
    public int[] piles;
    public int h;
  }
  private void AssertAnswer(Parameters parameters, int desiredOutcome)
  {
    int actualOutcome = _solution.MinEatingSpeed(parameters.piles, parameters.h);
    Assert.Equal(desiredOutcome, actualOutcome);
  }
  [Fact]
  public void PilesOfLengthOne1()
  {
    Parameters parameters = new()
    {
      piles = [1],
      h = 1
    };

    int result = 1;
    AssertAnswer(parameters, result);
  }

  [Fact]
  public void PilesOfLengthOne2()
  {

    Parameters parameters = new()
    {
      piles = [4],
      h = 2
    };

    int result = 2;
    AssertAnswer(parameters, result);
  }
}
