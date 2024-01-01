namespace LeetCodeSolutions;
public class UniquePathsSolution
{
    private class PascalTriangle
    {
        private int[][] table;
        private readonly int m;
        private readonly int n;
        public PascalTriangle(int m, int n)
        {
            this.m = m;
            this.n = n;

            table = new int[m][];
            for (int i = 0; i < m; i++)
            {
                table[i] = new int[n];
            }

            PopulateOnesOfPascalTable();
        }

        private void PopulateOnesOfPascalTable()
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

        public int FinalTableCell => table[m - 1][n - 1];
    }


    public int UniquePaths(int m, int n)
    {
        PascalTriangle table = new(m, n);
        table.PopulateTableWithSums();
        return table.FinalTableCell;
    }
}
