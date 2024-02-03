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
}
