
namespace LeetCodeSolutions;
public class RottingOrangesSolution
{
    private string Encode(int num)
    {
        return num.ToString("000000");
    }
    private string CoordinatesToString(int x, int y)
    {
        return Encode(x) + Encode(y);
    }

    public int OrangesRotting(int[][] grid)
    {
        HashSet<string> allFresh = new();
        Queue<int[]> rottingNeighbors = new();
        int width = grid.Length;
        int height = grid[0].Length;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (grid[i][j] == 1)
                {
                    allFresh.Add(CoordinatesToString(i, j));
                }
                if (grid[i][j] == 2)
                {
                    if (i > 0 && grid[i - 1][j] == 1)
                    {
                        rottingNeighbors.Enqueue([i - 1, j]);
                    }

                    if (i < width - 1 && grid[i + 1][j] == 1)
                    {
                        rottingNeighbors.Enqueue([i + 1, j]);
                    }

                    if (j > 0 && grid[i][j - 1] == 1)
                    {
                        rottingNeighbors.Enqueue([i, j - 1]);
                    }

                    if (j < height - 1 && grid[i][j + 1] == 1)
                    {
                        rottingNeighbors.Enqueue([i, j + 1]);
                    }
                }
            }
        }

        int minutes = 0;

        while (rottingNeighbors.Count > 0)
        {
            int neighborCount = rottingNeighbors.Count;
            for (int i = 0; i < neighborCount; i++)
            {
                int[] current = rottingNeighbors.Dequeue();
                int x = current[0];
                int y = current[1];

                allFresh.Remove(CoordinatesToString(x, y));

                if (x > 0 && allFresh.Contains(CoordinatesToString(x - 1, y)))
                {
                    rottingNeighbors.Enqueue([x - 1, y]);
                }

                if (x < width - 1 && allFresh.Contains(CoordinatesToString(x + 1, y)))
                {
                    rottingNeighbors.Enqueue([x + 1, y]);
                }

                if (y > 0 && allFresh.Contains(CoordinatesToString(x, y - 1)))
                {
                    rottingNeighbors.Enqueue([x, y - 1]);
                }

                if (y < height - 1 && allFresh.Contains(CoordinatesToString(x, y + 1)))
                {
                    rottingNeighbors.Enqueue([x, y + 1]);
                }

            }
            minutes++;
        }


        return allFresh.Count == 0 ? minutes : -1;
    }

}