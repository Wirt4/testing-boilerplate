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
  public void Example1()
  {
    int[][] cities = [[1, 1, 0], [1, 1, 0], [0, 0, 1]];
    Assert.Equal(2, _solution.FindCircleNum(cities));
  }
  [Fact]
  public void Example2()
  {
    int[][] cities = [[1, 0, 0], [0, 1, 0], [0, 0, 1]];
    Assert.Equal(3, _solution.FindCircleNum(cities));
  }
}
