namespace Tests;
using LeetCodeSolutions;
public class NonOverlappingIntervalsTests
{
  private class TestWrapper(int[][] intervals)
  {
    private readonly int[][] _intervals = intervals;
    private readonly NonOverlappingIntervalsSolution _solution = new();

    public void AssertAnswerIsEqualTo(int expected)
    {
      int actual = _solution.EraseOverlapIntervals(_intervals);
      Assert.Equal(expected, actual);
    }
  }
  [Fact]
  public void NoRemovalsNecessary1()
  {
    TestWrapper test = new([[1, 2]]);
    test.AssertAnswerIsEqualTo(0);
  }

  [Fact]
  public void OneRemovalNecessary1()
  {
    TestWrapper test = new([[1, 2], [1, 2]]);
    test.AssertAnswerIsEqualTo(1);
  }

  [Fact]
  public void LCExample2()
  {
    TestWrapper test = new([[1, 2], [1, 2], [1, 2]]);
    test.AssertAnswerIsEqualTo(2);
  }
}
