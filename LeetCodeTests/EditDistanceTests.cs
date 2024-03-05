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
  public void WordsAreSame()
  {
    Assert.Equal(0, _solution.MinDistance("pigs", "pigs"));
  }
}
