using System.Dynamic;

namespace LeetCodeSolutions;
public class ReorderRoutesToLeadToZeroSolution
{
    public int MinReorder(int n, int[][] connections)
    {
        Dictionary<int, HashSet<int>> ConnectionsDefault = new();
        Dictionary<int, HashSet<int>> ConnectionsReversed = new();
        foreach (int[] connection in connections)
        {
            if (ConnectionsDefault.ContainsKey(connection[0]))
            {
                ConnectionsDefault[connection[0]].Add(connection[1]);
            }
            else
            {
                ConnectionsDefault.Add(connection[0], new());
                ConnectionsDefault[connection[0]].Add(connection[1]);
            }

            if (ConnectionsReversed.ContainsKey(connection[1]))
            {
                ConnectionsReversed[connection[1]].Add(connection[0]);
            }
            else
            {
                ConnectionsReversed.Add(connection[1], new());
                ConnectionsReversed[connection[1]].Add(connection[0]);
            }
        }

        Stack<int> Adjacent = new();
        HashSet<int> visited = [0];
        int flips = 0;
        if (connections[0][0] == 0)
        {
            foreach (int connection in ConnectionsDefault[0])
            {
                Adjacent.Push(connection);
            }
        }
        else
        {
            foreach (int connection in ConnectionsReversed[0])
            {
                Adjacent.Push(connection);
            }
        }


        while (Adjacent.Count > 0 && visited.Count < n)
        {
            int currentNode = Adjacent.Pop();
            visited.Add(currentNode);

            if (ConnectionsDefault.ContainsKey(currentNode))
            {

                foreach (int connection in ConnectionsDefault[currentNode])
                {
                    if (!visited.Contains(connection))
                    {
                        Adjacent.Push(connection);
                    }
                }
            }
            else if (ConnectionsReversed.ContainsKey(currentNode))
            {
                flips++;
                foreach (int connection in ConnectionsReversed[currentNode])
                {
                    if (!visited.Contains(connection))
                    {
                        Adjacent.Push(connection);
                    }
                }

            }
            else
            {
                throw new Exception("hash sets not built properly");
            }



        }



        return flips;
    }
}
