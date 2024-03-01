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

  [Fact]
  public void PilesOfLengthTwo1()
  {

    Parameters parameters = new()
    {
      piles = [4, 8],
      h = 2
    };

    int result = 8;
    AssertAnswer(parameters, result);
  }
  [Fact]
  public void PilesOfLengthTwo2()
  {

    Parameters parameters = new()
    {
      piles = [3, 6],
      h = 3
    };

    int result = 3;
    AssertAnswer(parameters, result);
  }

  [Fact]
  public void LCExample1()
  {
    Parameters parameters = new()
    {
      piles = [3, 6, 7, 11],
      h = 8
    };

    int result = 4;
    AssertAnswer(parameters, result);
  }


  [Fact]
  public void LCExample2()
  {
    Parameters parameters = new()
    {
      piles = [30, 11, 23, 4, 20],
      h = 5
    };

    int result = 30;
    AssertAnswer(parameters, result);
  }

  [Fact]
  public void LCExample3()
  {
    Parameters parameters = new()
    {
      piles = [30, 11, 23, 4, 20],
      h = 6
    };

    int result = 23;
    AssertAnswer(parameters, result);
  }

  [Fact]
  public void FailingTest1()
  {
    Parameters parameters = new()
    {
      piles = [312884470],
      h = 312884469
    };

    int result = 2;
    AssertAnswer(parameters, result);
  }

  [Fact]
  public void RateLowerThanPileAmount()
  {
    Parameters parameters = new()
    {
      piles = [12, 12],
      h = 24
    };

    int result = 1;
    AssertAnswer(parameters, result);
  }
}
