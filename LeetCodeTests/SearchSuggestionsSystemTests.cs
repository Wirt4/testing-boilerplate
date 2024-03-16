namespace Tests;
using LeetCodeSolutions;
public class SearchSuggestionsSystemTests
{

  private class TestWrapper
  {
    private string[] _products;
    private string _searchWord;
    private SearchSuggestionsSystemSolution _solution;
    public TestWrapper(string[] products, string searchWord)
    {
      _products = products;
      _searchWord = searchWord;
      _solution = new();
    }

    public void AssertAnswerIsEqualTo(IList<IList<string>> expected)
    {
      IList<IList<string>> answer = _solution.SuggestedProducts(_products, _searchWord);
      Assert.Equal(expected, answer);
    }
  }

  [Fact]
  public void LCExample1()
  {
    string[] products = ["mobile", "mouse", "moneypot", "monitor", "mousepad"];
    TestWrapper test = new(products, "mouse");
    IList<IList<string>> output = [["mobile", "moneypot", "monitor"], ["mobile", "moneypot", "monitor"], ["mouse", "mousepad"], ["mouse", "mousepad"], ["mouse", "mousepad"]];
    test.AssertAnswerIsEqualTo(output);
  }

  [Fact]
  public void LCExample1SubProblem()
  {

    SearchSuggestionsSystemSolution.SearchTrie searchTrie = new();
    searchTrie.InsertAll(["mobile", "mouse", "moneypot", "monitor", "mousepad"]);
    Assert.Equal(["mouse", "mousepad"], searchTrie.Matches("mous"));
  }

  [Fact]
  public void LCExample2()
  {
    string[] products = ["havana"];
    TestWrapper test = new(products, "havana");
    IList<IList<string>> output = [["havana"], ["havana"], ["havana"], ["havana"], ["havana"], ["havana"]];
    test.AssertAnswerIsEqualTo(output);
  }
}
