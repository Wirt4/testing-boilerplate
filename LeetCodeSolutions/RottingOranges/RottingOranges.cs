namespace LeetCodeSolutions;
public class RottingOrangesSolution
{
    private class Coordinates
    {
        private readonly int _x;
        private readonly int _y;
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

        private static string Encode(int num)
        {
            return num.ToString("000000");
        }
        public string ToString()
        {
            return Encode(_x) + Encode(_y);
        }
    }

    private class GridWrapper
    {
        private int[][] _grid;
        private int i;
        private int j;
        public GridWrapper(int[][] grid)
        {
            _grid = grid;
            i = 0;
            j = 0;
        }

        public bool Traversed => i >= _grid.Length;

        public void Iterate()
        {
            j++;
            if (j >= _grid[0].Length)
            {
                j = 0;
                i++;
            }
        }

        public Coordinates GetCurrentCoordinates()
        {
            return new(i, j);
        }

        private bool AreValidCoordinates(Coordinates coords)
        {
            return coords.X >= 0 && coords.Y >= 0 && coords.X < _grid.Length && coords.Y < _grid[0].Length;
        }

        public bool IsFresh(Coordinates coords)
        {
            return AreValidCoordinates(coords) && _grid[coords.X][coords.Y] == 1;
        }

        public bool IsRotten(Coordinates coords)
        {
            return AreValidCoordinates(coords) && _grid[coords.X][coords.Y] == 2;
        }

    }

    public int OrangesRotting(int[][] grid)
    {
        HashSet<string> allFresh = new();
        Queue<Coordinates> rottingNeighbors = new();
        GridWrapper gridWrapper = new(grid);
        while (!gridWrapper.Traversed)
        {
            Coordinates current = gridWrapper.GetCurrentCoordinates();
            if (gridWrapper.IsFresh(current))
            {
                allFresh.Add(current.ToString());
            }
            if (gridWrapper.IsRotten(current))
            {
                Coordinates left = new(current.X - 1, current.Y);
                if (gridWrapper.IsFresh(left))
                {
                    rottingNeighbors.Enqueue(left);
                }

                Coordinates right = new(current.X + 1, current.Y);

                if (gridWrapper.IsFresh(right))
                {
                    rottingNeighbors.Enqueue(right);
                }

                Coordinates top = new(current.X, current.Y - 1);
                if (gridWrapper.IsFresh(top))
                {
                    rottingNeighbors.Enqueue(top);
                }

                Coordinates bottom = new(current.X, current.Y + 1);
                if (gridWrapper.IsFresh(bottom))
                {
                    rottingNeighbors.Enqueue(bottom);
                }
            }

            gridWrapper.Iterate();
        }

        int minutes = 0;

        while (rottingNeighbors.Count > 0)
        {

            foreach (Coordinates neighbor in rottingNeighbors)
            {
                allFresh.Remove(neighbor.ToString());
            }

            int neighborCount = rottingNeighbors.Count;
            for (int i = 0; i < neighborCount; i++)
            {
                Coordinates current = rottingNeighbors.Dequeue();

                Coordinates left = new(current.X - 1, current.Y);
                if (allFresh.Contains(left.ToString()))
                {
                    rottingNeighbors.Enqueue(left);
                }
                Coordinates right = new(current.X + 1, current.Y);
                if (allFresh.Contains(right.ToString()))
                {
                    rottingNeighbors.Enqueue(right);
                }

                Coordinates top = new(current.X, current.Y - 1);
                if (allFresh.Contains(top.ToString()))
                {
                    rottingNeighbors.Enqueue(top);
                }
                Coordinates bottom = new(current.X, current.Y + 1);
                if (allFresh.Contains(bottom.ToString()))
                {
                    rottingNeighbors.Enqueue(bottom);
                }
            }
            minutes++;
        }


        return allFresh.Count == 0 ? minutes : -1;
    }

}