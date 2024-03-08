namespace Tests;


using LeetCodeSolutions;
public class UniquePathsTests
{
  private UniquePathsSolution _solution;
  public UniquePathsTests()
  {
    _solution = new();
  }
  private class Arguments
  {
    public int m;
    public int n;
  }
  private void TestUniquePaths(Arguments arguments, int expected)
  {
    int acutal = _solution.UniquePaths(arguments.m, arguments.n);
    Assert.Equal(expected, acutal);
  }
  [Fact]
  public void GridOfOne()
  {

    Arguments args = new()
    {
      m = 1,
      n = 1
    };
    int expected = 1;
    TestUniquePaths(args, expected);
  }
  [Fact]
  public void LCExample1()
  {
    Arguments args = new()
    {
      m = 3,
      n = 7
    };
    int expected = 28;
    TestUniquePaths(args, expected);
  }

  [Fact]
  public void LCExample2()
  {
    Arguments args = new()
    {
      m = 3,
      n = 2
    };
    int expected = 3;
    TestUniquePaths(args, expected);
  }

}
