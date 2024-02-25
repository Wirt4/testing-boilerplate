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
            Coordinates left = new(coords.X - 1, coords.Y);
            if (IsFresh(left))
            {
                neighbors.Add(left);
            }

            Coordinates right = new(coords.X + 1, coords.Y);

            if (IsFresh(right))
            {
                neighbors.Add(right);
            }

            Coordinates top = new(coords.X, coords.Y - 1);
            if (IsFresh(top))
            {
                neighbors.Add(top);
            }

            Coordinates bottom = new(coords.X, coords.Y + 1);
            if (IsFresh(bottom))
            {
                neighbors.Add(bottom);
            }

            return neighbors;
        }

    }

    private class Oranges
    {
        private HashSet<string> allFresh;
        private Queue<Coordinates> rottingNeighbors;

        public Oranges()
        {
            allFresh = new();
            rottingNeighbors = new();
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

        public bool IsRotting()
        {
            return rottingNeighbors.Count > 0;
        }

        public int CurrentlyRottingOranges()
        {
            return rottingNeighbors.Count;
        }

        public Coordinates GetRottingOrange()
        {
            return rottingNeighbors.Dequeue();
        }

    }
    public int OrangesRotting(int[][] grid)
    {
        Oranges oranges = new();
        GridWrapper gridWrapper = new(grid);
        while (!gridWrapper.Traversed)
        {
            Coordinates current = gridWrapper.GetCurrentCoordinates();
            if (gridWrapper.IsFresh(current))
            {
                oranges.AddFresh(current);
            }
            if (gridWrapper.IsRotten(current))
            {
                List<Coordinates> neighbors = gridWrapper.FreshNeighbors(current);
                foreach (Coordinates neighbor in neighbors)
                {
                    oranges.Enqueue(neighbor);
                }
            }

            gridWrapper.Iterate();
        }

        int minutes = 0;

        while (oranges.IsRotting())
        {
            oranges.RotAdjacentOranges();

            int rottingOranges = oranges.CurrentlyRottingOranges();
            for (int i = 0; i < rottingOranges; i++)
            {
                Coordinates current = oranges.GetRottingOrange();
                List<Coordinates> neighbors = gridWrapper.FreshNeighbors(current);
                foreach (Coordinates neighbor in neighbors)
                {
                    oranges.EnqueueIfFresh(neighbor);
                }
            }
            minutes++;
        }
        if (oranges.HasFresh())
        {
            return -1;
        }

        return minutes;
    }

}