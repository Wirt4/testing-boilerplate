namespace LeetCodeSolutions;
public class ReorderRoutesToLeadToZeroSolution
{
    private class Connection(int neighbor, bool correctDirection)
    {
        public int Neighbor = neighbor;
        public bool CorrectDirection = correctDirection;
    }

    private class GraphSearcher
    {
        public int Count;

        private readonly List<List<Connection>> adjacents;
        public GraphSearcher(int n, ref int[][] connections)
        {
            Count = 0;
            adjacents = [];

            for (int i = 0; i < n; i++)
            {
                adjacents.Add([]);
            }

            foreach (int[] connection in connections)
            {
                AddTuple(0, connection);
                AddTuple(1, connection);
            }
        }

        private void AddTuple(int ndx, int[] connection)
        {
            int ndx2 = ndx == 0 ? 1 : 0;

            adjacents[connection[ndx]].Add(new Connection(connection[ndx2], ndx2 == 0));

        }

        public void DepthFirstSearch(int node = 0, int parent = -1)
        {
            foreach (Connection connection in adjacents[node])
            {
                if (connection.Neighbor != parent)
                {

                    if (!connection.CorrectDirection)
                    {
                        Count++;
                    }

                    DepthFirstSearch(connection.Neighbor, node);
                }
            }
        }
    }


    public int MinReorder(int n, int[][] connections)
    {
        GraphSearcher searcher = new(n, ref connections);
        searcher.DepthFirstSearch();
        return searcher.Count;
    }
}
