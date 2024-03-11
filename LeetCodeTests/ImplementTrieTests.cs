namespace Tests;

using LeetCodeSolutions;
public class ImplementTrieTests
{

  [Fact]
  public void SearchWordTrue()
  {
    Trie _Trie = new();
    _Trie.Insert("word");
    Assert.True(_Trie.Search("word"));
  }

  [Fact]
  public void SearchWordFalse()
  {
    Trie _Trie = new();
    _Trie.Insert("word");
    Assert.False(_Trie.Search("bird"));
  }

  [Fact]
  public void StartsWithTrue()
  {
    Trie _Trie = new();
    _Trie.Insert("word");
    Assert.True(_Trie.StartsWith("wo"));
  }
  [Fact]
  public void StartsWithFalse()
  {
    Trie _Trie = new();
    _Trie.Insert("word");
    Assert.False(_Trie.StartsWith("he"));
  }
}
