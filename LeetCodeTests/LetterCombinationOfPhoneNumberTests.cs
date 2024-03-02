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
}
