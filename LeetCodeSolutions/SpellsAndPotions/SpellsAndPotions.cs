namespace LeetCodeSolutions;
public class SpellsAndPotionsSolution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        int[] answer = new int[spells.Length];
        for (int i = 0; i < spells.Length; i++)
        {
            int currentMatch = 0;
            for (int j = 0; j < potions.Length; j++)
            {
                if (spells[i] * potions[j] >= success)
                {
                    currentMatch++;
                }
            }


            answer[i] = currentMatch;
        }

        return answer;
    }
}
