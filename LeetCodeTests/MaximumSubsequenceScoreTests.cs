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
}
