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
        Assert.Equal(1, stockSpanner.Next(60));
        Assert.Equal(4, stockSpanner.Next(75));
    }

    [Fact]
    public void Example2(){
        StockSpanner stockSpanner = new StockSpanner();
        stockSpanner.Next(7);
        stockSpanner.Next(2);
        stockSpanner.Next(1);
        stockSpanner.Next(2);
        Assert.Equal(4, stockSpanner.Next(2));
    }

    [Fact]
    public void Example3(){
        StockSpanner stockSpanner = new StockSpanner();
        stockSpanner.Next(7);
        stockSpanner.Next(34);
        stockSpanner.Next(1);
        stockSpanner.Next(2);
        Assert.Equal(3, stockSpanner.Next(8));
    }
}