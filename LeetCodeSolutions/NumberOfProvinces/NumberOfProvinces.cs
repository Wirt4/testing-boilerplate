
namespace LeetCodeSolutions;
public class NumberOfProvincesSolution
{
    private class GraphTraveler
    {
        private readonly HashSet<int> remaining;
        private readonly Stack<int> adjacent;
        private readonly int[][] graph;
        public GraphTraveler(int[][] graph)
        {
            remaining = new();
            for (int i = 0; i < graph.Length; i++)
            {
                remaining.Add(i);
            }

            adjacent = new();
            adjacent.Push(0);
            this.graph = graph;
        }

        public void TraverseNextProvence()
        {
            while (adjacent.Count > 0)
            {
                int i = adjacent.Pop();
                remaining.Remove(i);

                foreach (int j in remaining)
                {
                    if (graph[i][j] == 1)
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
        GraphTraveler graphTraveler = new(isConnected);
        int provinces = 0;

        while (!graphTraveler.Traversed)
        {
            graphTraveler.TraverseNextProvence();
            provinces++;
            graphTraveler.GetNextCity();
        }

        return provinces;
    }
}
