namespace Tests;
using LeetCodeSolutions;
public class CombinationSumIIITests
{
  private CombinationSumIIISolution _solution;

  private class TestWrapper
  {
    private int k;
    private int n;
    private CombinationSumIIISolution _solution;
    public TestWrapper(int k, int n)
    {
      this.k = k;
      this.n = n;
      _solution = new();
    }

    public void AssertOutputEqualTo(IList<IList<int>> expectedAnswer)
    {
      IList<IList<int>> actual = _solution.CombinationSum3(k, n);
      Assert.Equal(expectedAnswer, actual);
    }
  }

  [Fact]
  public void ArrayOfOne1()
  {
    TestWrapper wrapper = new(1, 1);
    IList<IList<int>> desired = [[1]];
    wrapper.AssertOutputEqualTo(desired);
  }

  [Fact]
  public void ArrayOfOne2()
  {
    TestWrapper wrapper = new(1, 7);
    IList<IList<int>> desired = [[7]];
    wrapper.AssertOutputEqualTo(desired);
  }

  [Fact]
  public void ArrayOfTwo1()
  {
    TestWrapper wrapper = new(2, 3);
    IList<IList<int>> desired = [[1, 2]];
    wrapper.AssertOutputEqualTo(desired);
  }

  [Fact]
  public void LCExample1()
  {
    TestWrapper wrapper = new(3, 7);
    IList<IList<int>> desired = [[1, 2, 4]];
    wrapper.AssertOutputEqualTo(desired);
  }

  [Fact]
  public void LCExample2()
  {
    TestWrapper wrapper = new(3, 9);
    IList<IList<int>> desired = [[1, 2, 6], [1, 3, 5], [2, 3, 4]];
    wrapper.AssertOutputEqualTo(desired);
  }
  [Fact]
  public void LCExample3()
  {
    TestWrapper wrapper = new(4, 1);
    IList<IList<int>> desired = [];
    wrapper.AssertOutputEqualTo(desired);
  }
}
