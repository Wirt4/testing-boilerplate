namespace Tests;
using LeetCodeSolutions;
public class MaximumSubsequenceScoreTests
{
  private MaximumSubsequenceScoreSolution _solution;
  public MaximumSubsequenceScoreTests()
  {
    _solution = new();
  }

  private void TestFunction(int[] nums1, int[] nums2, int k, int expectedAnswer)
  {
    Assert.Equal(expectedAnswer, _solution.MaxScore(nums1, nums2, k));
  }
  [Fact]
  public void MinimumValuesCase()
  {
    int[] nums1 = [0];
    int[] nums2 = [0];
    int k = 1;
    int expectedAnswer = 0;

    TestFunction(nums1, nums2, k, expectedAnswer);
  }

  [Fact]
  public void SmallNonZeroCase()
  {
    int[] nums1 = [1, 2];
    int[] nums2 = [1, 2];
    int k = 2;
    int expectedAnswer = 3;

    TestFunction(nums1, nums2, k, expectedAnswer);
  }

  [Fact]
  public void LCCodeExample1()
  {
    int[] nums1 = [1, 3, 3, 2];
    int[] nums2 = [2, 1, 3, 4];
    int k = 3;
    int expectedAnswer = 12;

    TestFunction(nums1, nums2, k, expectedAnswer);
  }

}
