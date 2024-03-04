namespace Tests;
using LeetCodeSolutions;
public class BestTimeToBuyStockTests
{
  private BestTimeToBuyStockSolution _solution;
  public BestTimeToBuyStockTests()
  {
    _solution = new();
  }
  private class Parameters
  {
    public int[] prices;
    public int fee;
  }

  private void TestFunction(Parameters paramteters, int expected)
  {
    int actual = _solution.MaxProfit(paramteters.prices, paramteters.fee);
    Assert.Equal(expected, actual);
  }

  [Fact]
  public void ArrayOfTwo1()
  {
    Parameters parameters = new()
    {
      prices = [1, 8],
      fee = 2
    };
    int expected = 5;
    TestFunction(parameters, expected);
  }

  [Fact]
  public void ArrayOfTwo2()
  {
    Parameters parameters = new()
    {
      prices = [4, 9],
      fee = 3
    };
    int expected = 2;
    TestFunction(parameters, expected);
  }

  [Fact]
  public void LCExample1()
  {
    Parameters parameters = new()
    {
      prices = [1, 3, 2, 8, 4, 9],
      fee = 2
    };
    int expected = 8;
    TestFunction(parameters, expected);
  }
  [Fact]
  public void LCExample2()
  {
    Parameters parameters = new()
    {
      prices = [1, 3, 7, 5, 10, 3],
      fee = 3
    };
    int expected = 6;
    TestFunction(parameters, expected);
  }
}
