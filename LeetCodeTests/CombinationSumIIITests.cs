namespace Tests;
using LeetCodeSolutions;
public class CombinationSumIIITests
{
  private CombinationSumIIISolution _solution;
  public CombinationSumIIITests()
  {
    _solution = new();
  }
  [Fact]
  public void ArrayOfOne1()
  {
    int k = 1;
    int n = 1;
    IList<IList<int>> desired = [[1]];
    IList<IList<int>> actual = _solution.CombinationSum3(k, n);

    Assert.Equal(desired, actual);
  }

  [Fact]
  public void ArrayOfOne2()
  {
    int k = 1;
    int n = 7;
    IList<IList<int>> desired = [[7]];
    IList<IList<int>> actual = _solution.CombinationSum3(k, n);

    Assert.Equal(desired, actual);
  }
}
