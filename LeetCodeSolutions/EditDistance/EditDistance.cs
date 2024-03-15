namespace LeetCodeSolutions;
public class EditDistanceSolution
{

    private class LevenshteinTable
    {
        private readonly string string1;
        private readonly string string2;
        private int[][]? table;
        public LevenshteinTable(string word1, string word2)
        {
            string1 = AddSpaceForBaseCase(word1);
            string2 = AddSpaceForBaseCase(word2);
            InitializeTable();
        }

        private static string AddSpaceForBaseCase(string s)
        {
            return " " + s;
        }

        private void InitializeTable()
        {
            table = new int[string1.Length][];
            for (int i = 0; i < string1.Length; i++)
            {
                table[i] = new int[string2.Length];
                table[i][0] = i;
            }
            for (int i = 0; i < string2.Length; i++)
            {
                table[0][i] = i;
            }
        }

        public void CalculateSubProblems()
        {
            for (int i = 1; i < string1.Length; i++)
            {
                for (int j = 1; j < string2.Length; j++)
                {
                    SetMinimum(i, j);
                }
            }
        }

        private void SetMinimum(int ndxI, int ndxJ)
        {
            int previousCost = table[ndxI - 1][ndxJ - 1];
            if (string1[ndxI] == string2[ndxJ])
            {
                table[ndxI][ndxJ] = previousCost;
                return;

            }
            int previousInsertionCost = table[ndxI][ndxJ - 1];
            int previousDeletionCost = table[ndxI - 1][ndxJ];
            int minimum = Math.Min(previousCost, Math.Min(previousInsertionCost, previousDeletionCost));
            table[ndxI][ndxJ] = minimum + 1;
        }

        public int LastCell => table != null ? table[string1.Length - 1][string2.Length - 1] : -1;
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

