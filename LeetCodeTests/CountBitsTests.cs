namespace Tests;
using LeetCodeSolutions;
public class CountBitsTests
{
  private CountBitsSolution _solution;
  public CountBitsTests()
  {
    _solution = new();
  }

  [Fact]
  public void LCExample1()
  {
    Assert.Equal([0, 1, 1], _solution.CountBits(2));
  }
  [Fact]
  public void LCExample2()
  {
    Assert.Equal([0, 1, 1, 2, 1, 2], _solution.CountBits(5));
  }
}
