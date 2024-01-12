using LeetCodeSolutions;

namespace Tests;

public class StockSpannerTests{
    [Fact]
    public void Example1(){
        StockSpanner stockSpanner = new StockSpanner();
        Assert.Equal(1, stockSpanner.Next(100));
        Assert.Equal(1, stockSpanner.Next(80));
        Assert.Equal(1, stockSpanner.Next(60));
        Assert.Equal(2, stockSpanner.Next(70));
    }
}