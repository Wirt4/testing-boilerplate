namespace Tests;
using LeetCodeSolutions;
public class NumberOfProvincesTests
{
  private NumberOfProvincesSolution _solution;
  public NumberOfProvincesTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example2()
  {
    int[][] cities = [[1, 0, 0], [0, 1, 0], [0, 0, 1]];
    Assert.Equal(0, _solution.FindCircleNum(cities));
  }
}
