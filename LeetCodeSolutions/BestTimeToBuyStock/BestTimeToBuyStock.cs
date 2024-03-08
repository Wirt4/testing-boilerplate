
namespace LeetCodeSolutions;
public class BestTimeToBuyStockSolution
{
    public int MaxProfit(int[] prices, int fee)
    {
        int arrLength = prices.Length + 1;
        int[] buys = new int[arrLength];
        int[] sales = new int[arrLength];

        for (int i = prices.Length - 1; i >= 0; i--)
        {
            int futureIndex = i + 1;
            buys[i] = Math.Max(buys[futureIndex], sales[futureIndex] - prices[i]);
            sales[i] = Math.Max(sales[futureIndex], buys[futureIndex] + prices[i] - fee);
        }

        return buys[0];
    }
}
