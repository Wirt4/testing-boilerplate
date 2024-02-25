namespace Tests;
using LeetCodeSolutions;
public class NearestExitFromMazeTests
{
  private NearestExitFromMazeSolution _solution;
  public NearestExitFromMazeTests()
  {
    _solution = new();
  }
  [Fact]
  public void LCExample1()
  {
    char[][] maze = [['+', '+', '.', '+'], ['.', '.', '.', '+'], ['+', '+', '+', '.']];
    int[] entrance = [1, 2];
    int answer = _solution.NearestExit(maze, entrance);
    int expected = 1;
    Assert.Equal(expected, answer);
  }

  [Fact]
  public void LCExample2()
  {
    char[][] maze = [['+', '+', '+'], ['.', '.', '.'], ['+', '+', '+']];
    int[] entrance = [1, 0];
    int answer = _solution.NearestExit(maze, entrance);
    int expected = 2;
    Assert.Equal(expected, answer);
  }

  [Fact]
  public void LCExample3()
  {
    char[][] maze = [['.', '+']];
    int[] entrance = [0, 0];
    int answer = _solution.NearestExit(maze, entrance);
    int expected = -1;
    Assert.Equal(expected, answer);
  }
}
