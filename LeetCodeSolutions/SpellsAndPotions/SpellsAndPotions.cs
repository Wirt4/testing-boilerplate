namespace LeetCodeSolutions;
public class SpellsAndPotionsSolution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        if (spells[0] * potions[0] >= success)
        {
            return [1];
        }
        return [0];
    }
}
