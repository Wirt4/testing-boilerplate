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
    ListNode basicInput = LinkedListTesting.ListFromArray([1, 2]);
    Assert.Equal(3, _solution.PairSum(basicInput));
  }

  [Fact]
  public void Example3()
  {
    ListNode basicInput = LinkedListTesting.ListFromArray([1, 100000]);
    Assert.Equal(100000, _solution.PairSum(basicInput));
  }
}
