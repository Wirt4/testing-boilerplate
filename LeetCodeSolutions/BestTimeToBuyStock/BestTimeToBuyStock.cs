namespace LeetCodeSolutions;
public class BestTimeToBuyStockSolution
{
    public int MaxProfit(int[] prices, int fee)
    {
        return Helper(0, true, fee, ref prices);
    }
    private int Helper(int indx, bool buy, int fee, ref int[] prices)
    {
        if (indx == prices.Length)
        {
            return 0;
        }
        // there are two options: to take action or move on
        int noTransaction = Helper(indx + 1, buy, fee, ref prices);

        int transaction;
        if (buy)
        {
            transaction = Helper(indx + 1, !buy, fee, ref prices) - prices[indx];
        }
        else
        {
            transaction = prices[indx] - fee + Helper(indx + 1, !buy, fee, ref prices);
        }

        return Math.Max(noTransaction, transaction);

    }
}
