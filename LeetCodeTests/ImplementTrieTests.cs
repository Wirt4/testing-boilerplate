namespace Tests;

using System.Diagnostics.CodeAnalysis;
using LeetCodeSolutions;
public class ImplementTrieTests
{
  private ImplementTrieSolution _Trie;
  [Fact]
  public void SearchWordTrue()
  {
    _Trie = new();
    _Trie.Insert("word");
    Assert.True(_Trie.Search("word"));
  }
}
