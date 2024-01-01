namespace Tests;
using LeetCodeSolutions;
public class KokoEatsBananasTests
{
  private KokoEatsBananasSolution _solution;


  private class TestWrapper
  {
    public TestWrapper(int[] piles, int h)
    {
      this.piles = piles;
      this.h = h;
      _solution = new();
    }
    private KokoEatsBananasSolution _solution;
    private int[] piles;
    private int h;

    public void AssertAnswer(int desiredOutcome)
    {
      int actualOutcome = _solution.MinEatingSpeed(piles, h);
      Assert.Equal(desiredOutcome, actualOutcome);
    }
  }
  [Fact]
  public void PilesOfLengthOne1()
  {
    TestWrapper parameters = new([1], 1);
    parameters.AssertAnswer(1);
  }

  [Fact]
  public void PilesOfLengthOne2()
  {
    TestWrapper parameters = new([4], 2);
    parameters.AssertAnswer(2);
  }

  [Fact]
  public void PilesOfLengthTwo1()
  {
    TestWrapper parameters = new([4, 8], 2);
    parameters.AssertAnswer(8);
  }

  [Fact]
  public void PilesOfLengthTwo2()
  {
    TestWrapper parameters = new([3, 6], 3);
    parameters.AssertAnswer(3);
  }

  [Fact]
  public void LCExample1()
  {
    TestWrapper parameters = new([3, 6, 7, 11], 8);
    parameters.AssertAnswer(4);
  }


  [Fact]
  public void LCExample2()
  {
    TestWrapper parameters = new([30, 11, 23, 4, 20], 5);
    parameters.AssertAnswer(30);
  }

  [Fact]
  public void LCExample3()
  {
    TestWrapper parameters = new([30, 11, 23, 4, 20], 6);
    parameters.AssertAnswer(23);
  }

  [Fact]
  public void FailingTest1()
  {
    TestWrapper parameters = new([312884470], 312884469);
    parameters.AssertAnswer(2);
  }

  [Fact]
  public void RateLowerThanPileAmount()
  {
    TestWrapper parameters = new([12, 12], 24);
    parameters.AssertAnswer(1);
  }
}
