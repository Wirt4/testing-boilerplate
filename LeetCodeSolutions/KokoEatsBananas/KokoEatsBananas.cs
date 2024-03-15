namespace LeetCodeSolutions;
public class KokoEatsBananasSolution
{
    private static bool IsViableRate(int rate, int[] piles, int h)
    {
        foreach (int pile in piles)
        {
            h -= CelingDivide(pile, rate);

            if (h < 0)
            {
                return false;
            }
        }

        return true;
    }

    private static int CelingDivide(int numerator, int divisor)
    {
        return (numerator + divisor - 1) / divisor;
    }
    public int MinEatingSpeed(int[] piles, int h)
    {
        (int min, int max) rates = new(piles[0], piles[0]);
        foreach (int pile in piles)
        {
            rates.min = Math.Min(rates.min, pile);
            rates.max = Math.Max(rates.max, pile);
        }
        if (piles.Length == h)
        {
            return rates.max;
        }
        rates.min = CelingDivide(rates.min, h);
        while (rates.min < rates.max)
        {
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
