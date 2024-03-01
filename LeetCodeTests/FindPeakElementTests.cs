namespace Tests;
using LeetCodeSolutions;
public class FindPeakElementTests
{
  private FindPeakElementSolution _solution;
  public FindPeakElementTests()
  {
    _solution = new();
  }
  [Fact]
  public void ArrayOfOne()
  {
    int[] nums = [1];
    int desiredOutput = 0;

    int actualOutput = _solution.FindPeakElement(nums);
    Assert.Equal(actualOutput, desiredOutput);
  }
  [Fact]
  public void ArrayOfTwo1()
  {
    int[] nums = [1, 2];
    int desiredOutput = 1;

    int actualOutput = _solution.FindPeakElement(nums);
    Assert.Equal(actualOutput, desiredOutput);
  }
}
