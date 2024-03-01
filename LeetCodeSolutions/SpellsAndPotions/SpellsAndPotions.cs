namespace LeetCodeSolutions;
public class SpellsAndPotionsSolution
{


    private class PotionsContainer
    {
        private readonly int[] potions;
        private readonly long success;
        public PotionsContainer(int[] potions, long success)
        {
            this.potions = potions;
            Array.Sort(this.potions);
            this.success = success;
        }

        private int Find(int spell, int[] potions, long success)
        {
            //assumss potions is sorted
            int i = 0;
            int j = potions.Length;
            while (i <= j)
            {
                if (i == j)
                {
                    return i;
                }
                int m = (i + j) / 2;
                long query = spell * potions[m];
                if (query == success)
                {
                    return m;
                }
                if (query > success)
                {
                    if (m == 0)
                    {
                        return m;
                    }
                    long query2 = spell * potions[m - 1];
                    if (query2 < success)
                    {
                        return m;
                    }
                    j = m - 1;
                }
                else
                {
                    i = m + 1;
                }
            }
            return -1;
        }

        public int NumberOfMixes(int spell)
        {
            int index = Find(spell, potions, success);
            if (index == -1)
            {
                return 0;
            }
            return potions.Length - index;
        }
    };
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        PotionsContainer continer = new(potions, success);
        int[] answer = new int[spells.Length];
        for (int i = 0; i < spells.Length; i++)
        {
            answer[i] = continer.NumberOfMixes(spells[i]);
        }

        return answer;
    }
}
