namespace LeetCodeSolutions;
public class KokoEatsBananasSolution
{
    private bool IsViableRate(int rate, int[] piles, int h)
    {
        foreach (int pile in piles)
        {
            h -= (pile + rate - 1) / rate;
        }
        return h >= 0;
    }
    public int MinEatingSpeed(int[] piles, int h)
    {
        if (piles.Length == 1)
        {
            return piles[0] / h;
        }


        if (piles.Length == h)
        {
            return piles[^1];
        }
        (int min, int max) rates = new(piles[0], piles[0]);
        foreach (int pile in piles)
        {
            rates.min = Math.Min(rates.min, pile);
            rates.max = Math.Max(rates.max, pile);
        }


        while (rates.min < rates.max)
        {
            if (rates.min == rates.max)
            {
                return rates.min;
            }
            int m = (rates.min + rates.max) / 2;
            if (IsViableRate(m, piles, h))
            {
                rates.max = m;
                continue;
            }
            rates.min = m + 1;
        }

        return rates.min;
    }
}
