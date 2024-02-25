namespace Tests;
using LeetCodeSolutions;
public class KthLargestElementTests
{
  private KthLargestElementSolution _solution;
  public KthLargestElementTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    int[] nums = [3, 2, 1, 5, 6, 4];
    int k = 2;
    int desired = 5;

    int actual = _solution.FindKthLargest(nums, k);
    Assert.Equal(desired, actual);
  }

  [Fact]
  public void Example2()
  {
    int[] nums = [3, 2, 3, 1, 2, 4, 5, 5, 6];
    int k = 4;
    int desired = 4;

    int actual = _solution.FindKthLargest(nums, k);
    Assert.Equal(desired, actual);
  }
}
