namespace Tests;
using LeetCodeSolutions;
public class MaximumTwinSumTests
{
  private MaximumTwinSumSolution _solution;
  public MaximumTwinSumTests()
  {
    _solution = new();
  }

  [Fact]
  public void BasicCase()
  {
    PairSumTest(3, [1, 2]);
  }

  [Fact]
  public void Example1()
  {
    PairSumTest(6, [5, 4, 2, 1]);
  }

  [Fact]
  public void Example2()
  {
    PairSumTest(7, [4, 2, 2, 3]);
  }

  [Fact]
  public void Example3()
  {
    PairSumTest(100001, [1, 100000]);
  }

  private void PairSumTest(int Output, int[] ListValues)
  {
    ListNode valuesAsList = LinkedListTesting.ListFromArray(ListValues);
    Assert.Equal(Output, _solution.PairSum(valuesAsList));
  }
}
