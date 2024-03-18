namespace Tests;
using LeetCodeSolutions;
public class BalloonsTests
{
  private class TestWrapper(int[][] points)
  {
    int[][] _points = points;
    private BalloonsSolution _solution = new();

    public void AssertAnswerEqualTo(int expected)
    {
      int acutal = _solution.FindMinArrowShots(_points);
      Assert.Equal(expected, acutal);
    }
  }
  [Fact]
  public void ArrayOfOne()
  {
    TestWrapper test = new([[1, 2]]);
    test.AssertAnswerEqualTo(1);

  }
  [Fact]
  public void ArrayOfTwoNoOverLap()
  {
    TestWrapper test = new([[1, 2], [4, 5]]);
    test.AssertAnswerEqualTo(2);

  }
  [Fact]
  public void ArrayOfTwoOverLap()
  {
    TestWrapper test = new([[1, 4], [3, 5]]);
    test.AssertAnswerEqualTo(1);
  }

  [Fact]
  public void LCExample1()
  {
    TestWrapper test = new([[10, 16], [2, 8], [1, 6], [7, 12]]);
    test.AssertAnswerEqualTo(2);
  }

  [Fact]
  public void LCExample2()
  {
    TestWrapper test = new([[1, 2], [3, 4], [5, 6], [7, 8]]);
    test.AssertAnswerEqualTo(4);
  }

  [Fact]
  public void LCExample3()
  {
    TestWrapper test = new([[1, 2], [2, 3], [3, 4], [4, 5]]);
    test.AssertAnswerEqualTo(2);
  }
  [Fact]
  public void BreakingCase1()
  {
    TestWrapper test = new([[-1, 1], [0, 1], [2, 3], [1, 2]]);
    test.AssertAnswerEqualTo(2);
  }

}
