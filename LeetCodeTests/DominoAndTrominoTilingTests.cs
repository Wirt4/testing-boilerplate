namespace Tests;
using LeetCodeSolutions;
public class DominoAndTrominoTilingTests
{
  private class TestWrapper(int n)
  {
    private int _n = n;
    private DominoAndTrominoTilingSolution _solution = new();

    public void AssertNumTilingsIsEqualTo(int desired)
    {
      int actual = _solution.NumTilings(_n);
      Assert.Equal(desired, actual);
    }
  }
  [Fact]
  public void LCExample2()
  {
    TestWrapper testWrapper = new(1);
    testWrapper.AssertNumTilingsIsEqualTo(1);
  }

  [Fact]
  public void TwoByTwoGrid()
  {
    TestWrapper testWrapper = new(2);
    testWrapper.AssertNumTilingsIsEqualTo(2);
  }

  [Fact]
  public void LCExample1()
  {
    TestWrapper testWrapper = new(3);
    testWrapper.AssertNumTilingsIsEqualTo(5);
  }

  [Fact]
  public void BreakingCase1()
  {
    TestWrapper testWrapper = new(30);
    testWrapper.AssertNumTilingsIsEqualTo(312342182);
  }
}
