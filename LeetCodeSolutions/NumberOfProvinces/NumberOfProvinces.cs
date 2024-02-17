
namespace LeetCodeSolutions;
public class NumberOfProvincesSolution
{
    private class GraphTraveler
    {
        private HashSet<int> remaining;
        private Stack<int> adjacent;
        public GraphTraveler(int n)
        {
            remaining = new(n);
            for (int i = 0; i < n; i++)
            {
                remaining.Add(i);
            }

            adjacent = new();
            adjacent.Push(0);
        }

        public void TraverseNextProvence(ref int[][] isConnected)
        {
            while (adjacent.Count > 0)
            {
                int i = adjacent.Pop();
                remaining.Remove(i);

                foreach (int j in remaining)
                {
                    if (isConnected[i][j] == 1)
                    {
                        adjacent.Push(j);
                    }
                }
            }
        }

        public void GetNextCity()
        {
            if (remaining.Count > 0)
            {
                foreach (int unVisited in remaining)
                {
                    adjacent.Push(unVisited);
                    return;
                }
            }
        }
        public bool Traversed => remaining.Count == 0;
    }
    public int FindCircleNum(int[][] isConnected)
    {
        GraphTraveler graphTraveler = new(isConnected.Length);
        int provinces = 0;

        while (!graphTraveler.Traversed)
        {
            graphTraveler.TraverseNextProvence(ref isConnected);
            provinces++;
            graphTraveler.GetNextCity();
        }

        return provinces;
    }
}
