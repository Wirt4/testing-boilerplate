namespace LeetCodeSolutions;
public class BestTimeToBuyStockSolution
{
    public int MaxProfit(int[] prices, int fee)
    {
        return prices[1] - prices[0] - fee;
    }
}
