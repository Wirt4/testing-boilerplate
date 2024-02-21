namespace LeetCodeSolutions;
public class ReorderRoutesToLeadToZeroSolution
{
    private class Connection(int neighbor, bool correctionNeeded)
    {
        public int Neighbor = neighbor;
        public bool CorrectionNeeded = correctionNeeded;
    }

    private class Graph
    {
        public int DirectionReversalsNeeded;

        private readonly List<List<Connection>> adjacents;
        public Graph(int n, ref int[][] connections)
        {
            DirectionReversalsNeeded = 0;
            adjacents = [];

            for (int i = 0; i < n; i++) { adjacents.Add([]); }

            foreach (int[] connection in connections)
            {
                AddConnection(0, connection);
                AddConnection(1, connection);
            }
        }

        private void AddConnection(int ndx, int[] connection)
        {
            bool correctionNeeded = ndx == 0;
            int ndx2 = correctionNeeded ? 1 : 0;

            adjacents[connection[ndx]].Add(new Connection(connection[ndx2], correctionNeeded));

        }

        public void DepthFirstTraversal(int node = 0, int parent = -1)
        {
            foreach (Connection connection in adjacents[node])
            {
                if (connection.Neighbor != parent)
                {
                    if (connection.CorrectionNeeded) DirectionReversalsNeeded++;

                    DepthFirstTraversal(connection.Neighbor, node);
                }
            }
        }
    }


    public int MinReorder(int n, int[][] connections)
    {
        Graph searcher = new(n, ref connections);
        searcher.DepthFirstTraversal();
        return searcher.DirectionReversalsNeeded;
    }
}
