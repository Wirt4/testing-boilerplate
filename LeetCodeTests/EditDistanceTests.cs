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
  public void OnceCHarWordsAreSame()
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

  [Fact]
  public void TestBlankDistanceTable()
  {
    int[][] answer = [[0, 1], [1, 0]];
    Assert.Equal(answer, _solution.GenerateBlankTable("a", "a"));
  }

  [Fact]
  public void TestBlankDistanceTable2()
  {
    int[][] answer = [
      [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
      [1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [2, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [3, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [4, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [5, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [6, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [7, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [8, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [9, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    ];
    Assert.Equal(answer, _solution.GenerateBlankTable("intention", "execution"));
  }

  [Fact]
  public void TestBlankDistanceTableDifferentWordLengths()
  {
    int[][] answer = [
      [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
      [1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [2, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [3, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      [4, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    ];
    Assert.Equal(answer, _solution.GenerateBlankTable("intention", "damn"));
  }

}
