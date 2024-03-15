namespace Tests;
using LeetCodeSolutions;


public class LetterCombinationOfPhoneNumberTests
{
  private class TestWrapper
  {
    private string input;
    private LetterCombinationOfPhoneNumberSolution _solution;
    public TestWrapper(string input)
    {
      this.input = input;
      _solution = new();
    }

    public void AssertIsEqualTo(IList<string> desiredOutcome)
    {
      IList<string> result = _solution.LetterCombinations(input);
      Assert.Equal(desiredOutcome, result);
    }
  }

  [Fact]
  public void EmptyString()
  {
    TestWrapper test = new("");
    test.AssertIsEqualTo([]);
  }

  [Fact]
  public void StringOfLength1Case1()
  {
    TestWrapper test = new("2");
    test.AssertIsEqualTo(["a", "b", "c"]);
  }

  [Fact]
  public void StringOfLength1Case2()
  {
    TestWrapper test = new("7");
    test.AssertIsEqualTo(["p", "q", "r", "s"]);
  }

  [Fact]
  public void Example1()
  {
    TestWrapper test = new("23");
    IList<string> output = ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"];
    test.AssertIsEqualTo(output);
  }

  [Fact]
  public void Example22()
  {
    TestWrapper test = new("22");
    IList<string> output = ["aa", "ab", "ac", "ba", "bb", "bc", "ca", "cb", "cc"];
    test.AssertIsEqualTo(output);
  }
}