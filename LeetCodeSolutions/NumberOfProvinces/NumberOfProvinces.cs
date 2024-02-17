
namespace LeetCodeSolutions;
public class NumberOfProvincesSolution
{

    public int FindCircleNum(int[][] isConnected)
    {
        HashSet<int> remaining = new();
        for (int i = 0; i < isConnected.Length; i++)
        {
            remaining.Add(i);
        }
        Stack<int> adjacent = new();
        adjacent.Push(0);
        int provinces = 0;
        int curNdex;

        while (remaining.Count > 0)
        {
            while (adjacent.Count > 0)
            {
                curNdex = adjacent.Pop();
                remaining.Remove(curNdex);
                for (int j = 0; j < isConnected.Length; j++)
                {
                    if (remaining.Contains(j) && isConnected[curNdex][j] == 1)
                    {
                        adjacent.Push(j);
                    }
                }
            }

            provinces++;

            foreach (int unVisited in remaining)
            {
                adjacent.Push(unVisited);
                break;
            }
        }

        return provinces;
    }
}
