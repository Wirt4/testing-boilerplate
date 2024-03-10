namespace Tests;
using LeetCodeSolutions;
public class SingleNumberTests
{


  private class SingleNumberTester
  {
    private SingleNumberSolution _solution;
    private int[] _nums;
    public SingleNumberTester(int[] nums)
    {
      _nums = nums;
      _solution = new();
    }

    public void AssertSingleNumberOutputEquals(int expectedAnswer)
    {
      int output = _solution.SingleNumber(_nums);
      Assert.Equal(expectedAnswer, output);
    }
  }
  [Fact]
  public void MinimumCase1()
  {
    SingleNumberTester singleNumber = new([2, 2, 1]);
    singleNumber.AssertSingleNumberOutputEquals(1);

  }
}
