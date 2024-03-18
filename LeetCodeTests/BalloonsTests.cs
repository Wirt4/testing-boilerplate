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
}
