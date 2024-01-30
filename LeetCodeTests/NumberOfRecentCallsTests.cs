namespace Tests;
using LeetCodeSolutions;
 public class NumberOfRecentCallsTests {
  private RecentCounter _solution;
  public NumberOfRecentCallsTests (){
      _solution = new();
  }
  [Fact]
  public void Example1(){
    Assert.Equal(1, _solution.Ping(1));
    Assert.Equal(2, _solution.Ping(100));
    Assert.Equal(3, _solution.Ping(3001));
    Assert.Equal(3, _solution.Ping(3002));
  }
}
