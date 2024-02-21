namespace LeetCodeSolutions;
public class ReorderRoutesToLeadToZeroSolution
{

    int count = 0;
    void dfs(int node, int parent, ref List<List<Tuple<int, int>>> adj)
    {
        foreach (Tuple<int, int> pair in adj[node])
        {
            if (pair.Item1 != parent)
            {
                count += pair.Item2;
                dfs(pair.Item1, node, ref adj);
            }
        }
    }
    public int MinReorder(int n, int[][] connections)
    {
        List<List<Tuple<int, int>>> adj = new();
        for (int i = 0; i < n; i++)
        {
            adj.Add([]);
        }

        foreach (int[] connetion in connections)
        {
            adj[connetion[0]].Add(new Tuple<int, int>(connetion[1], 1));
            adj[connetion[1]].Add(new Tuple<int, int>(connetion[0], 0));
        }

        dfs(0, -1, ref adj);
        return count;
    }
}
