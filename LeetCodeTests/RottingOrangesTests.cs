namespace Tests;
using LeetCodeSolutions;
public class RottingOrangesTests
{
  private RottingOrangesSolution _solution;
  public RottingOrangesTests()
  {
    _solution = new();
  }
  [Fact]
  public void LCExample1()
  {
    int[][] grid = [[2, 1, 1], [1, 1, 0], [0, 1, 1]];
    int desiredOutput = 4;
    int output = _solution.OrangesRotting(grid);
    Assert.Equal(desiredOutput, output);
  }

  [Fact]
  public void LCExample2()
  {
    int[][] grid = [[2, 1, 1], [0, 1, 1], [1, 0, 1]];
    int desiredOutput = -1;
    int output = _solution.OrangesRotting(grid);
    Assert.Equal(desiredOutput, output);
  }

  [Fact]
  public void LCExample3()
  {
    int[][] grid = [[0, 2]];
    int desiredOutput = 0;
    int output = _solution.OrangesRotting(grid);
    Assert.Equal(desiredOutput, output);
  }

  [Fact]
  public void BreakingCase1()
  {
    int[][] grid = [[0]];
    int desiredOutput = 0;
    int output = _solution.OrangesRotting(grid);
    Assert.Equal(desiredOutput, output);
  }

  [Fact]
  public void BreakingCase12()
  {
    int[][] grid = [[2], [2], [1], [0], [1], [1]];
    int desiredOutput = -1;
    int output = _solution.OrangesRotting(grid);
    Assert.Equal(desiredOutput, output);
  }
}
