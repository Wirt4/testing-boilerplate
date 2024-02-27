namespace Tests;
using LeetCodeSolutions;
public class MaximumSubsequenceScoreTests
{
  private MaximumSubsequenceScoreSolution _solution;
  public MaximumSubsequenceScoreTests()
  {
    _solution = new();
  }
  [Fact]
  public void MinimumValuesCase()
  {
    int[] nums1 = [0];
    int[] nums2 = [0];
    int k = 1;
    int expectedAnswer = 0;

    long actualAnswer = _solution.MaxScore(nums1, nums2, k);
    Assert.Equal(expectedAnswer, actualAnswer);
  }

  [Fact]
  public void SmallNonZeroCase()
  {
    int[] nums1 = [1, 2];
    int[] nums2 = [1, 2];
    int k = 2;
    int expectedAnswer = 3;

    long actualAnswer = _solution.MaxScore(nums1, nums2, k);
    Assert.Equal(expectedAnswer, actualAnswer);
  }

  [Fact]
  public void LCCodeExample1()
  {
    int[] nums1 = [1, 3, 3, 2];
    int[] nums2 = [2, 1, 3, 4];
    int k = 3;
    int expectedAnswer = 12;

    long actualAnswer = _solution.MaxScore(nums1, nums2, k);
    Assert.Equal(expectedAnswer, actualAnswer);
  }

}
