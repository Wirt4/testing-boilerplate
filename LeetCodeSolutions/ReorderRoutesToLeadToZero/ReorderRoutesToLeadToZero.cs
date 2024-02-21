namespace LeetCodeSolutions;
public class ReorderRoutesToLeadToZeroSolution
{

    private class GraphSearcher
    {
        public int Count;

        private List<List<Tuple<int, int>>> adj;
        public GraphSearcher(int n, ref int[][] connections)
        {
            Count = 0;
            adj = new();

            for (int i = 0; i < n; i++)
            {
                adj.Add([]);
            }

            foreach (int[] connetion in connections)
            {
                adj[connetion[0]].Add(new Tuple<int, int>(connetion[1], 1));
                adj[connetion[1]].Add(new Tuple<int, int>(connetion[0], 0));
            }
        }

        public void DepthFirstSearch(int node, int parent)
        {
            foreach (Tuple<int, int> pair in adj[node])
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
        searcher.DepthFirstSearch(0, -1);
        return searcher.Count;
    }
}
