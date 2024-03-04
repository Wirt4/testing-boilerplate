namespace Tests;
using LeetCodeSolutions;
public class BestTimeToBuyStockTests
{
  private BestTimeToBuyStockSolution _solution;
  public BestTimeToBuyStockTests()
  {
    _solution = new();
  }
  [Fact]
  public void ArrayOfTwo()
  {
    int[] prices = [1, 8];
    int fee = 2;
    int expected = 5;
    int actual = _solution.MaxProfit(prices, fee);
    Assert.Equal(expected, actual);
  }
}
