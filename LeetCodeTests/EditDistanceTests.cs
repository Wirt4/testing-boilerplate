namespace Tests;
using LeetCodeSolutions;
public class EditDistanceTests
{
  private EditDistanceSolution _solution;
  public EditDistanceTests()
  {
    _solution = new();
  }
  [Fact]
  public void OnceCHarWordsAreSame()
  {
    Assert.Equal(0, _solution.MinDistance("p", "p"));
  }

  [Fact]
  public void OneCharWordOneIsEmpty()
  {
    Assert.Equal(1, _solution.MinDistance("", "p"));
  }
}

