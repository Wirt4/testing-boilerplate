
namespace LeetCodeSolutions;
public class NumberOfProvincesSolution
{
    private class GraphTraveler
    {
        private readonly int[][] cityGraph;
        private HashSet<int> unvisitedCities;
        private Stack<int> adjacentCities;

        public GraphTraveler(int[][] graph)
        {
            cityGraph = graph;
            InitializeRemaining();
            InitializeAdjacentCities();
        }

        private void InitializeRemaining()
        {
            unvisitedCities = [];
            for (int i = 0; i < cityGraph.Length; i++)
            {
                unvisitedCities.Add(i);
            }
        }

        private void InitializeAdjacentCities()
        {
            adjacentCities = new();
            adjacentCities.Push(0);
        }

        public void TraverseNextProvence()
        {
            while (adjacentCities.Count > 0)
            {
                int i = adjacentCities.Pop();
                unvisitedCities.Remove(i);

                foreach (int j in unvisitedCities)
                {
                    if (cityGraph[i][j] == 1)
                    {
                        adjacentCities.Push(j);
                    }
                }
            }
        }

        public void GetNextCity()
        {
            if (unvisitedCities.Count > 0)
            {
                foreach (int unVisited in unvisitedCities)
                {
                    adjacentCities.Push(unVisited);
                    return;
                }
            }
        }

        public bool Traversed => unvisitedCities.Count == 0;
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
