
namespace LeetCodeSolutions;
public class RottingOrangesSolution
{
    private class Coordinates
    {
        private int _x;
        private int _y;
        public int X => _x;
        public int Y => _y;
        public Coordinates(int[] arr)
        {
            _x = arr[0];
            _y = arr[0];
        }

        public Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
    private string Encode(int num)
    {
        return num.ToString("000000");
    }
    private string CoordinatesToString(Coordinates coord)
    {
        return Encode(coord.X) + Encode(coord.Y);
    }

    public int OrangesRotting(int[][] grid)
    {
        HashSet<string> allFresh = new();
        Queue<Coordinates> rottingNeighbors = new();
        int width = grid.Length;
        int height = grid[0].Length;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Coordinates current = new(i, j);
                if (grid[i][j] == 1)
                {
                    allFresh.Add(CoordinatesToString(current));
                }
                if (grid[i][j] == 2)
                {
                    Coordinates left = new(current.X - 1, current.Y);
                    if (i > 0 && grid[i - 1][j] == 1)
                    {
                        rottingNeighbors.Enqueue(left);
                    }

                    Coordinates right = new(current.X + 1, current.Y);

                    if (i < width - 1 && grid[i + 1][j] == 1)
                    {
                        rottingNeighbors.Enqueue(right);
                    }

                    Coordinates top = new(current.X, current.Y - 1);
                    if (j > 0 && grid[i][j - 1] == 1)
                    {
                        rottingNeighbors.Enqueue(top);
                    }
                    Coordinates bottom = new(current.X, current.Y + 1);
                    if (j < height - 1 && grid[i][j + 1] == 1)
                    {
                        rottingNeighbors.Enqueue(bottom);
                    }
                }
            }
        }

        int minutes = 0;

        while (rottingNeighbors.Count > 0)
        {

            foreach (Coordinates neighbor in rottingNeighbors)
            {
                allFresh.Remove(CoordinatesToString(neighbor));
            }

            int neighborCount = rottingNeighbors.Count;
            for (int i = 0; i < neighborCount; i++)
            {
                Coordinates current = rottingNeighbors.Dequeue();

                Coordinates left = new(current.X - 1, current.Y);
                if (current.X > 0 && allFresh.Contains(CoordinatesToString(left)))
                {
                    rottingNeighbors.Enqueue(left);
                }
                Coordinates right = new(current.X + 1, current.Y);
                if (current.X < width - 1 && allFresh.Contains(CoordinatesToString(right)))
                {
                    rottingNeighbors.Enqueue(right);
                }

                Coordinates top = new(current.X, current.Y - 1);
                if (current.Y > 0 && allFresh.Contains(CoordinatesToString(top)))
                {
                    rottingNeighbors.Enqueue(top);
                }
                Coordinates bottom = new(current.X, current.Y + 1);
                if (current.Y < height - 1 && allFresh.Contains(CoordinatesToString(bottom)))
                {
                    rottingNeighbors.Enqueue(bottom);
                }

            }
            minutes++;
        }


        return allFresh.Count == 0 ? minutes : -1;
    }

}