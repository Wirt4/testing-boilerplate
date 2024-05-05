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
  public void DescriptionExample1()
  {
    double[] desiredAnswer = [6.00000, 0.50000, -1.00000, 1.00000, -1.00000];

    string[][] equations = [["a", "b"], ["b", "c"]];
    double[] values = [2.0, 3.0];
    string[][] queries = [["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"]];

    double[] actual = _solution.CalcEquation(equations, values, queries);

    Assert.Equal(desiredAnswer, actual);
  }

  [Fact]
  public void DescriptionExample2()
  {
    double[] desiredAnswer = [3.75000, 0.40000, 5.00000, 0.20000];

    string[][] equations = [["a", "b"], ["b", "c"], ["bc", "cd"]];
    double[] values = [1.5, 2.5, 5.0];
    string[][] queries = [["a", "c"], ["c", "b"], ["bc", "cd"], ["cd", "bc"]];

    double[] actual = _solution.CalcEquation(equations, values, queries);
    Assert.Equal(desiredAnswer, actual);
  }

  [Fact]
  public void DescriptionExample3()
  {
    double[] desiredAnswer = [0.50000, 2.00000, -1.00000, -1.00000];

    string[][] equations = [["a", "b"]];
    double[] values = [0.5];
    string[][] queries = [["a", "b"], ["b", "a"], ["a", "c"], ["x", "y"]];

    double[] actual = _solution.CalcEquation(equations, values, queries);
    Assert.Equal(desiredAnswer, actual);
  }

  [Fact]
  public void OnlyOneValidConnection()
  {
    double[] desiredAnswer = [-1.00000, -1.00000, 1.00000, 1.00000];

    string[][] equations = [["a", "b"], ["c", "d"]];
    double[] values = [1.0, 1.0];
    string[][] queries = [["a", "c"], ["b", "d"], ["b", "a"], ["d", "c"]];

    double[] actual = _solution.CalcEquation(equations, values, queries);
    Assert.Equal(desiredAnswer, actual);
  }
}
