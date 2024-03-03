namespace Tests;
using LeetCodeSolutions;
public class DominoAndTrominoTilingTests
{
  private DominoAndTrominoTilingSolution _solution;
  public DominoAndTrominoTilingTests()
  {
    _solution = new();
  }
  [Fact]
  public void LCExample2()
  {
    int n = 1;
    int desired = 1;
    int actual = _solution.NumTilings(n);
    Assert.Equal(desired, actual);
  }

  [Fact]
  public void TwoByTwoGrid()
  {
    int n = 2;
    int desired = 2;
    int actual = _solution.NumTilings(n);
    Assert.Equal(desired, actual);
  }

  [Fact]
  public void LCExample1()
  {
    int n = 3;
    int desired = 5;
    int actual = _solution.NumTilings(n);
    Assert.Equal(desired, actual);
  }
}
