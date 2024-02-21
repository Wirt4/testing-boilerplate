namespace Tests;
using LeetCodeSolutions;
public class EvaluateDivisionTests
{
  private EvaluateDivisionSolution _solution;
  public EvaluateDivisionTests()
  {
    _solution = new();
  }
  [Fact]
  public void Example1()
  {
    double[] desiredAnswer = [6.00000, 0.50000, -1.00000, 1.00000, -1.00000];

    string[][] equations = [["a", "b"], ["b", "c"]];
    double[] values = [2.0, 3.0];
    string[][] queries = [["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"]];

    double[] actual = _solution.CalcEquation(equations, values, queries);

    Assert.Equal(desiredAnswer, actual);
  }
}
