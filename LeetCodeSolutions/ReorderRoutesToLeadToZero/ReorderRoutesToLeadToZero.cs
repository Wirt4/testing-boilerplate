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
            bool directionChangeNeeded = ndx == 0;
            int nextNode = directionChangeNeeded ? connection[1] : connection[0];
            int prevNode = connection[ndx];

            adjacents[prevNode].Add(new Connection(nextNode, directionChangeNeeded));

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
