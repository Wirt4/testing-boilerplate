namespace Tests;

using System.Dynamic;
using LeetCodeSolutions;
public class SmallestNumberInInifiniteSetTests
{
  private SmallestInfiniteSet _smallestInfiniteSet;
  public SmallestNumberInInifiniteSetTests()
  {
    _smallestInfiniteSet = new();
  }
  [Fact]
  public void Example1()
  {
    SmallestInfiniteSet set = new();
    set.AddBack(2);
    Assert.Equal(1, set.PopSmallest());
    Assert.Equal(2, set.PopSmallest());
    Assert.Equal(3, set.PopSmallest());
    set.AddBack(1);
    Assert.Equal(1, set.PopSmallest());
    Assert.Equal(4, set.PopSmallest());
    Assert.Equal(5, set.PopSmallest());

  }

}
