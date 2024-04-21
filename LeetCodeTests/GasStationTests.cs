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
  [Fact]
  public void Test2()
  {
    Assert.Equal(0, _solution.CanCompleteCircuit([1], [1]));

  }

  [Fact]
  public void Test3()
  {
    Assert.Equal(3, _solution.CanCompleteCircuit([1, 2, 3, 4, 5], [3, 4, 5, 1, 2]));

  }

  [Fact]
  public void Test4()
  {
    Assert.Equal(-1, _solution.CanCompleteCircuit([2, 3, 4], [2, 3, 4]));

  }
  [Fact]
  public void Test5()
  {
    Assert.Equal(5, _solution.CanCompleteCircuit([5, 1, 2, 3, 4], [4, 4, 1, 5, 1]));

  }
}
