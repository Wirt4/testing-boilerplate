namespace LeetCodeSolutions;
public class KokoEatsBananasSolution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        if (piles.Length == 1)
        {
            return piles[0] / h;
        }

        Array.Sort(piles);
        if (piles.Length == h)
        {
            return piles[piles.Length - 1];
        }
        return -1;
    }
}
