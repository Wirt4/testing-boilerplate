namespace Tests;
using LeetCodeSolutions;
public class KokoEatsBananasTests
{
  private KokoEatsBananasSolution _solution;
  public KokoEatsBananasTests()
  {
    _solution = new();
  }
  [Fact]
  public void PileOfOne1()
  {
    int[] piles = [1];
    int h = 1;
    Assert.Equal(1, _solution.MinEatingSpeed(piles, h));
  }

  [Fact]
  public void PileOfOne2()
  {
    int[] piles = [4];
    int h = 2;
    Assert.Equal(2, _solution.MinEatingSpeed(piles, h));
  }
}
