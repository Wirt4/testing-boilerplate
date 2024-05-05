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
  [Fact]
  public void ArrayOfTwo2()
  {
    int[] nums = [2, 1];
    int desiredOutput = 0;

    int actualOutput = _solution.FindPeakElement(nums);
    Assert.Equal(actualOutput, desiredOutput);
  }

  [Fact]
  public void LeetCodeExample1()
  {
    int[] nums = [1, 2, 3, 1];
    int desiredOutput = 2;

    int actualOutput = _solution.FindPeakElement(nums);
    Assert.Equal(actualOutput, desiredOutput);
  }

  [Fact]
  public void LeetCodeExample2()
  {
    int[] nums = [1, 2, 1, 3, 5, 6, 4];
    int desiredOutput1 = 1;
    int desiredOutput2 = 5;

    int actualOutput = _solution.FindPeakElement(nums);
    Assert.True(actualOutput == desiredOutput1 || actualOutput == desiredOutput2);
  }

  [Fact]
  public void BreakingCase1()
  {
    int[] nums = [1, 2, 3];
    int desiredOutput = 2;

    int actualOutput = _solution.FindPeakElement(nums);
    Assert.Equal(desiredOutput, actualOutput);
  }
}
