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

  [Fact]

  public void LCExample1()
  {
    TestWrapper test = new([[1, 2], [2, 3], [3, 4], [1, 3]]);
    test.AssertAnswerIsEqualTo(1);
  }

  [Fact]
  public void BreakingCase1()
  {
    TestWrapper test = new([[1, 100], [11, 22], [1, 11], [2, 12]]);
    test.AssertAnswerIsEqualTo(2);
  }

  [Fact]
  public void BreakingCase2()
  {
    int[][] intervals = [[-52, 31], [-73, -26], [82, 97], [-65, -11], [-62, -49], [95, 99], [58, 95], [-31, 49], [66, 98], [-63, 2], [30, 47], [-40, -26]];
    TestWrapper test = new(intervals);
    test.AssertAnswerIsEqualTo(7);
  }
}
