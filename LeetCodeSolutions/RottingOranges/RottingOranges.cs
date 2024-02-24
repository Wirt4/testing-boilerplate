namespace LeetCodeSolutions;
public class RottingOrangesSolution
{
    private bool Isolated(int x, int y, ref int[][] grid)
    {
        if (grid.Length == 1 && grid[0].Length == 1)
        {
            return true;
        }

        //corner cases
        //top right
        if (x == 0 && y == 0)
        {
            return grid[0][1] == 0 && grid[1][0] == 0;
        }

        //top left
        if (x == 0 && y == grid[0].Length - 1)
        {
            return grid[0][1] == 0 && grid[0][y + 1] == 0;
        }


        //bottom right
        if (x == grid.Length - 1 && y == 0)
        {
            return grid[grid.Length - 1][1] == 0 && grid[grid.Length - 2][0] == 0;
        }
        //bottom left
        if (x == grid.Length - 1 && y == grid[0].Length - 1)
        {
            return grid[grid.Length - 1][grid[0].Length - 2] == 0 && grid[grid.Length - 2][grid[0].Length - 1] == 0;
        }

        //edges 
        if (x == 0)
        {
            return grid[x + 1][y] == 0 && grid[x][y - 1] == 0 && grid[x][y + 1] == 0;
        }

        if (x == grid.Length - 1)
        {
            return grid[x - 1][y] == 0 && grid[x][y - 1] == 0 && grid[x][y + 1] == 0;
        }

        if (y == 0)
        {
            return grid[x - 1][y] == 0 && grid[x + 1][y] == 0 && grid[x][y + 1] == 0;
        }
        if (y == grid.Length - 1)
        {
            return grid[x - 1][y] == 0 && grid[x + 1][y] == 0 && grid[x][y - 1] == 0;
        }

        return grid[x - 1][y] == 0 && grid[x + 1][y] == 0 && grid[x][y - 1] == 0 && grid[x][y + 1] == 0;
    }
    public int OrangesRotting(int[][] grid)
    {
        int minutes = 0;

        bool freshOrangesFoud;
        bool rottenOrangesFound = false;
        Stack<int[]> rotPoints = new();
        do
        {
            while (rotPoints.Count > 0)
            {
                int[] rotPoint = rotPoints.Pop();
                grid[rotPoint[0]][rotPoint[1]] = 2;
            }

            freshOrangesFoud = false;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    switch (grid[i][j])
                    {
                        case 0:
                            continue;
                        case 1:
                            freshOrangesFoud = true;
                            if (Isolated(i, j, ref grid))
                            {
                                return -1;
                            }

                            break;
                        case 2:
                            rottenOrangesFound = true;
                            if (i > 0 && grid[i - 1][j] == 1)
                            {
                                rotPoints.Push([i - 1, j]);
                            }

                            if (i < grid.Length - 1 && grid[i + 1][j] == 1)
                            {
                                rotPoints.Push([i + 1, j]);
                            }

                            if (j > 0 && grid[i][j - 1] == 1)
                            {
                                rotPoints.Push([i, j - 1]);
                            }

                            if (j < grid[0].Length - 1 && grid[i][j + 1] == 1)
                            {
                                rotPoints.Push([i, j + 1]);
                            }

                            break;
                    }

                }

                if (!rottenOrangesFound)
                {
                    return -1;
                }
            }
            minutes++;
        } while (freshOrangesFoud);

        return minutes - 1;
    }
}

