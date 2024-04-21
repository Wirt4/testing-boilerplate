namespace Tests;

using System.Diagnostics.CodeAnalysis;
using LeetCodeSolutions;
public class GasStationTests
{
  private GasStationSolution _solution;
  public GasStationTests()
  {
    _solution = new();
  }
  [Fact]
  public void Test1()
  {
    Assert.Equal(-1, _solution.CanCompleteCircuit([0], [1]));

  }
}
