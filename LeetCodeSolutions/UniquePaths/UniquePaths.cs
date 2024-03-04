

namespace LeetCodeSolutions;
public class UniquePathsSolution
{
    private int[][] AllocateSpaceForPascalTable(int m, int n)
    {
        int[][] table = new int[m][];
        for (int i = 0; i < m; i++)
        {
            table[i] = new int[n];
        }
        return table;
    }

    private void PopulateOnesOfPascalTable(ref int[][] table)
    {

        for (int i = 0; i < table.Length; i++)
        {
            table[i][0] = 1;

        }
        for (int i = 0; i < table[0].Length; i++)
        {
            table[0][i] = 1;
        }
    }

    private void PopulateTableWithSums(ref int[][] table)
    {
        for (int i = 1; i < table.Length; i++)
        {
            for (int j = 1; j < table[0].Length; j++)
            {
                table[i][j] = table[i - 1][j] + table[i][j - 1];
            }
        }
    }

    public int UniquePaths(int m, int n)
    {
        int[][] table = AllocateSpaceForPascalTable(m, n);
        PopulateOnesOfPascalTable(ref table);
        PopulateTableWithSums(ref table);
        return table[m - 1][n - 1];
    }
}
