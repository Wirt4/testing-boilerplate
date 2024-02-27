namespace Tests;
using LeetCodeSolutions;
public class TotalCostToHireKWorkersTests
{
  private TotalCostToHireKWorkersSolution _solution;
  public TotalCostToHireKWorkersTests()
  {
    _solution = new();
  }
  private class Parameters
  {
    public int[] costs;
    public int hiringQuota;
    public int selectionRange;
  }

  private void TestIt(Parameters p, long desiredAnswer)
  {
    long actualAnswer = _solution.TotalCost(p.costs, p.hiringQuota, p.selectionRange);
    Assert.Equal(desiredAnswer, actualAnswer);
  }
  [Fact]
  public void MinCase1()
  {

    Parameters p = new()
    {
      costs = [1, 2],
      hiringQuota = 1,
      selectionRange = 1
    };

    long desired = 1;
    TestIt(p, desired);
  }

  [Fact]
  public void LeetCodeExample1()
  {
    Parameters p = new()
    {
      costs = [17, 12, 10, 2, 7, 2, 11, 20, 8],
      hiringQuota = 3,
      selectionRange = 4
    };

    long desired = 11;

    TestIt(p, desired);
  }

  [Fact]
  public void LeetCodeExample2()
  {
    Parameters p = new()
    {
      costs = [1, 2, 4, 1],
      hiringQuota = 3,
      selectionRange = 3
    };

    long desired = 4;

    TestIt(p, desired);
  }
}
