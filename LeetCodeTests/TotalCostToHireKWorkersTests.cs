namespace Tests;
using LeetCodeSolutions;
public class TotalCostToHireKWorkersTests
{
  private TotalCostToHireKWorkersSolution _solution;
  public TotalCostToHireKWorkersTests()
  {
    _solution = new();
  }
  [Fact]
  public void MinCase1()
  {
    int[] costs = [1, 2];
    int quota = 1;
    int range = 1;

    long desired = 1;
    long actual = _solution.TotalCost(costs, quota, range);
    Assert.Equal(desired, actual);

  }
}
