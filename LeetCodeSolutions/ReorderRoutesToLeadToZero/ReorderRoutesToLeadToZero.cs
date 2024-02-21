namespace LeetCodeSolutions;
public class ReorderRoutesToLeadToZeroSolution
{

    private class GraphSearcher
    {
        public int Count;

        private readonly List<List<Tuple<int, int>>> adjacents;
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

            adjacents[connection[ndx]].Add(new Tuple<int, int>(connection[ndx2], ndx2));

        }

        public void DepthFirstSearch(int node = 0, int parent = -1)
        {
            foreach (Tuple<int, int> pair in adjacents[node])
            {
                if (pair.Item1 != parent)
                {
                    Count += pair.Item2;
                    DepthFirstSearch(pair.Item1, node);
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
