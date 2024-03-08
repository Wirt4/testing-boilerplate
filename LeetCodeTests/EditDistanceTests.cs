namespace Tests;
using LeetCodeSolutions;
public class EditDistanceTests
{
  private EditDistanceSolution _solution;
  public EditDistanceTests()
  {
    _solution = new();
  }
  private class Parameters
  {
    public string word1;
    public string word2;
  }
  private void TestMinDistance(Parameters parameters, int desiredOutcome)
  {
    int result = _solution.MinDistance(parameters.word1, parameters.word2);
    Assert.Equal(desiredOutcome, result);
  }
  [Fact]
  public void OnceCharWordsAreSame()
  {
    Parameters parameters = new()
    {
      word1 = "p",
      word2 = "p"
    };
    TestMinDistance(parameters, 0);
  }

  [Fact]
  public void OneCharWordOneIsEmpty()
  {
    Parameters parameters = new()
    {
      word1 = "",
      word2 = "p"
    };
    TestMinDistance(parameters, 1);
  }

  [Fact]
  public void LCExample1()
  {
    Parameters parameters = new()
    {
      word1 = "horse",
      word2 = "ros"
    };
    TestMinDistance(parameters, 3);
  }
}
