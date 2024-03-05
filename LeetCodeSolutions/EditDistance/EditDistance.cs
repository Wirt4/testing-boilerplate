namespace LeetCodeSolutions;
public class EditDistanceSolution
{
    public int[][] GenerateBlankTable(string word1, string word2)
    {
        int[][] table = new int[word2.Length + 1][];
        for (int i = 0; i <= word2.Length; i++)
        {
            table[i] = new int[word1.Length + 1];
        }

        for (int i = 0; i <= word2.Length; i++)
        {
            table[i][0] = i;
        }

        for (int i = 0; i <= word1.Length; i++)
        {
            table[0][i] = i;
        }
        return table;
    }
    public int MinDistance(string word1, string word2)
    {
        // create a table
        int[][] EditDistanceTable = new int[word1.Length + 1][];
        for (int i = 0; i <= word1.Length; i++)
        {
            EditDistanceTable[i] = new int[word2.Length + 1];
        }

        //initialize the border values
        for (int i = 0; i < EditDistanceTable.Length; i++)
        {
            EditDistanceTable[i][0] = i;
        }

        for (int i = 0; i < EditDistanceTable[0].Length; i++)
        {
            EditDistanceTable[0][i] = i;
        }
        return -1;
    }
}
