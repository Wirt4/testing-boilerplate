namespace LeetCodeSolutions;
public class RottingOrangesSolution
{

    private class OrangeGrove
    {
        private int[][] grid;
        public bool FreshOrangesFound;
        public bool RottenOrangesFound;

        public int Width => grid.Length;
        public int Height => grid[0].Length;

        public OrangeGrove(int[][] grid)
        {
            this.grid = grid;
            FreshOrangesFound = true;
            RottenOrangesFound = false;
        }

        public void MarkRotten(int[] rotPoint)
        {
            grid[rotPoint[0]][rotPoint[1]] = 2;
        }

        public int Orange(int x, int y)
        {
            return grid[x][y];
        }

        public bool InBoundsAndFresh(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                return false;
            }

            return Orange(x, y) == 1;
        }

        public bool Isolated(int x, int y)
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
    }
    public int OrangesRotting(int[][] grid)
    {
        int minutes = 0;

        OrangeGrove orangeGrove = new(grid);
        Stack<int[]> rotPoints = new();

        while (true)
        {
            while (rotPoints.Count > 0)
            {
                orangeGrove.MarkRotten(rotPoints.Pop());
            }

            orangeGrove.FreshOrangesFound = false;

            for (int i = 0; i < orangeGrove.Width; i++)
            {
                for (int j = 0; j < orangeGrove.Height; j++)
                {
                    switch (orangeGrove.Orange(i, j))
                    {
                        case 1:
                            orangeGrove.FreshOrangesFound = true;
                            if (orangeGrove.Isolated(i, j))
                            {
                                return -1;
                            }
                            break;
                        case 2:
                            orangeGrove.RottenOrangesFound = true;
                            if (orangeGrove.InBoundsAndFresh(i - 1, j))
                            {
                                rotPoints.Push([i - 1, j]);
                            }

                            if (orangeGrove.InBoundsAndFresh(i + 1, j))
                            {
                                rotPoints.Push([i + 1, j]);
                            }

                            if (orangeGrove.InBoundsAndFresh(i, j - 1))
                            {
                                rotPoints.Push([i, j - 1]);
                            }

                            if (orangeGrove.InBoundsAndFresh(i, j + 1))
                            {
                                rotPoints.Push([i, j + 1]);
                            }
                            break;
                    }

                }

                if (!orangeGrove.RottenOrangesFound)
                {
                    return -1;
                }
            }
            if (!orangeGrove.FreshOrangesFound)
            {
                return minutes;
            }
            minutes++;
        }
    }
}

