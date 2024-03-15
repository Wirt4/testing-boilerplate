namespace Tests;
using LeetCodeSolutions;
public class EditDistanceTests
{

  private class MinDistanceWrapper
  {
    private string word1;
    private string word2;
    private EditDistanceSolution _solution;

    public MinDistanceWrapper(string word1, string word2)
    {
      this.word1 = word1;
      this.word2 = word2;
      _solution = new();
    }

    public void AssertMinDistanceIsEqualTo(int desiredOutcome)
    {
      int result = _solution.MinDistance(word1, word2);
      Assert.Equal(desiredOutcome, result);
    }
  }

  [Fact]
  public void OnceCharWordsAreSame()
  {
    MinDistanceWrapper tester = new("p", "p");
    tester.AssertMinDistanceIsEqualTo(0);
  }

  [Fact]
  public void OneCharWordOneIsEmpty()
  {
    MinDistanceWrapper tester = new("", "p");
    tester.AssertMinDistanceIsEqualTo(1);
  }

  [Fact]
  public void LCExample1()
  {
    MinDistanceWrapper tester = new("horse", "ros");
    tester.AssertMinDistanceIsEqualTo(3);
  }

  [Fact]
  public void LCExample2()
  {
    MinDistanceWrapper tester = new("intention", "execution");
    tester.AssertMinDistanceIsEqualTo(5);
  }

  [Fact]
  public void BreakingCase1()
  {
    MinDistanceWrapper tester = new("a", "ab");
    tester.AssertMinDistanceIsEqualTo(1);
  }
}
