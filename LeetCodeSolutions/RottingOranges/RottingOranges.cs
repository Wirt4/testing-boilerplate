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

        public List<Coordinates> FreshNeighbors(Coordinates coords)
        {
            List<Coordinates> neighbors = new();

            Coordinates[] candidates = [new(coords.X - 1, coords.Y), new(coords.X + 1, coords.Y),
                new(coords.X, coords.Y - 1), new(coords.X, coords.Y + 1)];

            foreach (Coordinates candidate in candidates)
            {
                if (IsFresh(candidate))
                {
                    neighbors.Add(candidate);
                }
            }

            return neighbors;
        }

    }

    private class Oranges
    {
        private readonly HashSet<string> allFresh;
        private readonly Queue<Coordinates> rottingNeighbors;

        public Oranges(GridWrapper grid)
        {
            allFresh = new();
            rottingNeighbors = new();

            while (!grid.Traversed)
            {
                Coordinates current = grid.GetCurrentCoordinates();
                if (grid.IsFresh(current))
                {
                    AddFresh(current);
                }
                if (grid.IsRotten(current))
                {
                    List<Coordinates> neighbors = grid.FreshNeighbors(current);
                    foreach (Coordinates neighbor in neighbors)
                    {
                        Enqueue(neighbor);
                    }
                }

                grid.Iterate();
            }
        }
        public void EnqueueIfFresh(Coordinates coords)
        {
            if (allFresh.Contains(coords.ToString()))
            {
                Enqueue(coords);
            }
        }

        public bool HasFresh()
        {
            return allFresh.Count > 0;
        }

        public void RotAdjacentOranges()
        {
            foreach (Coordinates neighbor in rottingNeighbors)
            {
                allFresh.Remove(neighbor.ToString());
            }
        }

        public void AddFresh(Coordinates coords)
        {
            allFresh.Add(coords.ToString());
        }

        public void Enqueue(Coordinates coords)
        {
            rottingNeighbors.Enqueue(coords);
        }
        public int RottenCount => rottingNeighbors.Count;


        public Coordinates Dequeue()
        {
            return rottingNeighbors.Dequeue();
        }

    }

    public int OrangesRotting(int[][] grid)
    {
        GridWrapper gridWrapper = new(grid);
        Oranges oranges = new(gridWrapper);
        int minutes = 0;
        while (oranges.RottenCount > 0)
        {
            oranges.RotAdjacentOranges();

            int rottingOranges = oranges.RottenCount;
            for (int i = 0; i < rottingOranges; i++)
            {
                List<Coordinates> neighbors = gridWrapper.FreshNeighbors(oranges.Dequeue());
                foreach (Coordinates neighbor in neighbors)
                {
                    oranges.EnqueueIfFresh(neighbor);
                }
            }
            minutes++;
        }

        return oranges.HasFresh() ? -1 : minutes;
    }

}