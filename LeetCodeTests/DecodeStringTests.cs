namespace Tests;
using LeetCodeSolutions;
 public class DecodeStringTests {
  private DecodeStringSolution _solution;
  public DecodeStringTests (){
      _solution = new();
  }
  [Fact]
  public void Example1(){
    Assert.Equal("aaabcbc", _solution.DecodeString("3[a]2[bc]"));
  }

  [Fact]
  public void Example2(){
    Assert.Equal("accaccacc", _solution.DecodeString("3[a2[c]]"));
  }

  [Fact]
  public void BaseCase(){
     Assert.Equal("t", _solution.DecodeString("t"));
  }

  [Fact]
  public void MinimumCase1(){
    Assert.Equal("tttt", _solution.DecodeString("4[t]"));
  }

  [Fact]
  public void MinimumCase2(){
    Assert.Equal("bb", _solution.DecodeString("2[b]"));
  }

  [Fact]
  public void CharFollowedByEncoded(){
    Assert.Equal("acc", _solution.DecodeString("a2[c]"));
  }
}
