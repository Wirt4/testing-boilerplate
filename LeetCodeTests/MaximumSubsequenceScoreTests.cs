namespace Tests;
using LeetCodeSolutions;
public class MaximumSubsequenceScoreTests
{
  private MaximumSubsequenceScoreSolution _solution;
  public MaximumSubsequenceScoreTests()
  {
    _solution = new();
  }

  private class Parameters
  {
    public int[] nums1;
    public int[] nums2;
    public int k;
  }

  private void TestFunction(Parameters p, int expectedAnswer)
  {
    Assert.Equal(expectedAnswer, _solution.MaxScore(p.nums1, p.nums2, p.k));
  }
  [Fact]
  public void MinimumValuesCase()
  {
    Parameters p = new()
    {
      nums1 = [0],
      nums2 = [0],
      k = 1,
    };

    int expectedAnswer = 0;

    TestFunction(p, expectedAnswer);
  }

  [Fact]
  public void SmallNonZeroCase()
  {
    Parameters p = new()
    {
      nums1 = [1, 2],
      nums2 = [1, 2],
      k = 2,
    };

    int expectedAnswer = 3;

    TestFunction(p, expectedAnswer);
  }

  [Fact]
  public void LCCodeExample1()
  {
    Parameters p = new()
    {
      nums1 = [1, 3, 3, 2],
      nums2 = [2, 1, 3, 4],
      k = 3
    };

    int expectedAnswer = 12;

    TestFunction(p, expectedAnswer);
  }

  [Fact]
  public void LCCodeExample2()
  {
    Parameters p = new()
    {
      nums1 = [4, 2, 3, 1, 1],
      nums2 = [7, 5, 10, 9, 6],
      k = 1
    };

    int expectedAnswer = 30;

    TestFunction(p, expectedAnswer);
  }
  [Fact]
  public void BreakingCase1()
  {
    Parameters p = new()
    {
      nums1 = [2, 1, 14, 12],
      nums2 = [11, 7, 13, 6],
      k = 3
    };

    int expectedAnswer = 168;

    TestFunction(p, expectedAnswer);
  }

}
