namespace Tests;
using LeetCodeSolutions;
public class MinimumFlipsTests
{

  private class MinFlipsTest
  {
    private readonly int a;
    private readonly int b;
    private readonly int c;
    private MinimumFlipsSolution solution;
    public MinFlipsTest(int a, int b, int c)
    {
      solution = new();
      this.a = a;
      this.b = b;
      this.c = c;
    }

    public void AssertOutputIsEqualTo(int expectedOutput)
    {
      int actual = solution.MinFlips(a, b, c);
      Assert.Equal(expectedOutput, actual);
    }
  }
  [Fact]
  public void LCExample1()
  {
    MinFlipsTest test = new(2, 6, 5);
    test.AssertOutputIsEqualTo(3);
  }

  [Fact]
  public void LCExample2()
  {
    MinFlipsTest test = new(4, 2, 7);
    test.AssertOutputIsEqualTo(1);
  }

  [Fact]
  public void LCExample3()
  {
    MinFlipsTest test = new(1, 2, 3);
    test.AssertOutputIsEqualTo(0);
  }
}
