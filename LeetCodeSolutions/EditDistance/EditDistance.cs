namespace LeetCodeSolutions;
public class EditDistanceSolution
{

    private class LevenshteinTable
    {
        private string string1;
        private string string2
        ;
        private int[][] table;
        public LevenshteinTable(string word1, string word2)
        {
            string1 = AddLeadingSpacte(word1);
            string2 = AddLeadingSpacte(word2);
            table = InitializeTableSize();
        }

        /**
            the base case will always be an empty string, so adding a space the beginning to simulate that
        **/
        private string AddLeadingSpacte(string s)
        {
            return " " + s;
        }

        private int[][] InitializeTableSize()
        {
            int[][] LevenshteinTable = new int[string1.Length][];
            for (int i = 0; i < string1.Length; i++)
            {
                LevenshteinTable[i] = new int[string2.Length];
                LevenshteinTable[i][0] = i;
            }

            for (int i = 0; i < string2.Length; i++)
            {
                LevenshteinTable[i][0] = i;
            }

            return LevenshteinTable;
        }

        public void CalculateSubProblems()
        {
            for (int i = 1; i < string1.Length; i++)
            {
                for (int j = 1; j < string2.Length; j++)
                {
                    int previousCost = table[i - 1][j - 1];
                    if (string1[i] == string2[j])
                    {
                        table[i][j] = previousCost;
                        continue;
                    }
                    int previousInsertionCost = table[i][j - 1];
                    int previousDeletionCost = table[i - 1][j];
                    table[i][j] = Math.Min(previousCost, Math.Min(previousInsertionCost, previousDeletionCost)) + 1;
                }
            }
        }

        public int LastCell => table[string1.Length - 1][string2.Length - 1];
    }

    public int MinDistance(string word1, string word2)
    {
        if (word1.Length == 0)
        {
            return word2.Length;
        }

        LevenshteinTable table = new(word1, word2);
        table.CalculateSubProblems();

        return table.LastCell;
    }
}

