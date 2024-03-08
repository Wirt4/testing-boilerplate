using System.Globalization;

namespace LeetCodeSolutions;
public class EditDistanceSolution
{


    public int MinDistance(string word1, string word2)
    {
        word1 = " " + word1;
        word2 = " " + word2;
        int[][] LevenshteinTable = new int[word1.Length][];
        for (int i = 0; i < word1.Length; i++)
        {
            LevenshteinTable[i] = new int[word2.Length];
            LevenshteinTable[i][0] = i;
        }

        for (int i = 0; i < word2.Length; i++)
        {
            LevenshteinTable[0][i] = i;
        }

        for (int i = 1; i < word1.Length; i++)
        {
            for (int j = 1; j < word2.Length; j++)
            {
                int previousCost = LevenshteinTable[i - 1][j - 1];
                if (word1[i] == word2[j])
                {
                    LevenshteinTable[i][j] = previousCost;
                    continue;
                }
                int previousInsertionCost = LevenshteinTable[i][j - 1];
                int previousDeletionCost = LevenshteinTable[i - 1][j];
                LevenshteinTable[i][j] = Math.Min(previousCost, Math.Min(previousInsertionCost, previousDeletionCost)) + 1;
            }
        }

        return LevenshteinTable[word1.Length - 1][word2.Length - 1];
    }
}
