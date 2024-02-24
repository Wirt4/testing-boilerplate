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

        private bool OutsideBounds(int x, int y)
        {
            return x < 0 || y < 0 || x >= Width || y >= Height;
        }

        private bool IsNullOrEmpty(int x, int y)
        {
            if (OutsideBounds(x, y))
            {
                return true;
            }

            return grid[x][y] == 0;

        }
        public bool InBoundsAndFresh(int x, int y)
        {
            if (OutsideBounds(x, y))
            {
                return false;
            }

            return Orange(x, y) == 1;
        }

        public bool Isolated(int x, int y)
        {
            return IsNullOrEmpty(x - 1, y) && IsNullOrEmpty(x + 1, y) && IsNullOrEmpty(x, y - 1) && IsNullOrEmpty(x, y + 1);
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

