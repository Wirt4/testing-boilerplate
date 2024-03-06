namespace Tests;
using LeetCodeSolutions;
public class BestTimeToBuyStockTests
{
  private BestTimeToBuyStockSolution _solution;
  public BestTimeToBuyStockTests()
  {
    _solution = new();
  }

  private class TestWrapper
  {
    private int[] _prices;
    private int _fee;
    private BestTimeToBuyStockSolution _solution;

    public TestWrapper(int[] prices, int fee)
    {
      _prices = prices;
      _fee = fee;
      _solution = new();
    }

    public void AssertMaxProfitIsEqualTo(int expectedAnswer)
    {
      int actualAnswer = _solution.MaxProfit(_prices, _fee);
      Assert.Equal(expectedAnswer, actualAnswer);
    }
  }

  [Fact]
  public void ArrayOfTwo1()
  {
    TestWrapper testWrapper = new([1, 8], 2);
    testWrapper.AssertMaxProfitIsEqualTo(5);
  }

  [Fact]
  public void ArrayOfTwo2()
  {
    TestWrapper testWrapper = new([4, 9], 3);
    testWrapper.AssertMaxProfitIsEqualTo(2);
  }

  [Fact]
  public void LCExample1()
  {
    TestWrapper testWrapper = new([1, 3, 2, 8, 4, 9], 2);
    testWrapper.AssertMaxProfitIsEqualTo(8);
  }

  [Fact]
  public void LCExample2()
  {
    TestWrapper testWrapper = new([1, 3, 7, 5, 10, 3], 3);
    testWrapper.AssertMaxProfitIsEqualTo(6);
  }
}
