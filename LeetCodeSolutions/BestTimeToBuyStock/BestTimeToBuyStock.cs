
namespace LeetCodeSolutions;
public class BestTimeToBuyStockSolution
{
    public int MaxProfit(int[] prices, int fee)
    {
        int[] buys = new int[prices.Length + 1];
        int[] sales = new int[prices.Length + 1];
        for (int i = prices.Length - 1; i >= 0; i--)
        {
            buys[i] = Math.Max(buys[i + 1], sales[i + 1] - prices[i]);
            sales[i] = Math.Max(sales[i + 1], buys[i + 1] + prices[i] - fee);
        }
        return buys[0];
    }
}
