namespace Tests;
using LeetCodeSolutions;
using NuGet.Frameworks;

public class LetterCombinationOfPhoneNumberTests
{
  private LetterCombinationOfPhoneNumberSolution _solution;
  public LetterCombinationOfPhoneNumberTests()
  {
    _solution = new();
  }
  [Fact]
  public void EmptyString()
  {
    string input = "";
    IList<string> output = [];
    IList<string> result = _solution.LetterCombinations(input);
    Assert.Equal(output, result);
  }

  [Fact]
  public void StringOfLength1Case1()
  {
    string input = "2";
    IList<string> output = ["a", "b", "c"];
    IList<string> result = _solution.LetterCombinations(input);
    Assert.Equal(output, result);
  }

  [Fact]
  public void StringOfLength1Case2()
  {
    string input = "7";
    IList<string> output = ["p", "q", "r", "s"];
    IList<string> result = _solution.LetterCombinations(input);
    Assert.Equal(output, result);
  }
}