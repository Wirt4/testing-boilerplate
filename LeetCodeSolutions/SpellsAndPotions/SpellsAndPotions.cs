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

        private long Query(int spell, int index)
        {
            return spell * potions[index];
        }

        private int BinarySearch(decimal target, int i, int j)
        {
            while (i <= j)
            {
                if (i == j)
                {
                    return i;
                }
                int m = (i + j) / 2;

                if (potions[m] >= target)
                {
                    if (m == 0)
                    {
                        return m;
                    }
                    if (potions[m - 1] < target)
                    {
                        return m;
                    }
                    j = m - 1;
                    continue;
                }
                i = m + 1;
            }
            return -1;
        }

        private int Find(int spell)
        {
            decimal target = (decimal)success / (decimal)spell;
            return BinarySearch(target, 0, potions.Length);
        }

        public int NumberOfMixes(int spell)
        {
            int index = Find(spell);
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
