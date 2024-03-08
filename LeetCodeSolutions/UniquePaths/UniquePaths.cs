

using System.ComponentModel;

namespace LeetCodeSolutions;
public class UniquePathsSolution
{


    private class PascalTriangle
    {
        public int[][] table;
        public PascalTriangle(int m, int n)
        {
            table = new int[m][];
            for (int i = 0; i < m; i++)
            {
                table[i] = new int[n];
            }
        }

        public void PopulateOnesOfPascalTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                table[i][0] = 1;

            }
            for (int j = 0; j < table[0].Length; j++)
            {
                table[0][j] = 1;
            }
        }

        public void PopulateTableWithSums()
        {
            for (int i = 1; i < table.Length; i++)
            {
                for (int j = 1; j < table[0].Length; j++)
                {
                    table[i][j] = table[i - 1][j] + table[i][j - 1];
                }
            }
        }
    }


    public int UniquePaths(int m, int n)
    {
        PascalTriangle table = new(m, n);
        table.PopulateOnesOfPascalTable();
        table.PopulateTableWithSums();
        return table.table[m - 1][n - 1];
    }
}
