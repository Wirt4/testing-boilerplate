
namespace LeetCodeSolutions;
public class NumberOfProvincesSolution
{

    public int FindCircleNum(int[][] isConnected)
    {
        HashSet<int> visited = new();
        Stack<int> adjacent = new();
        adjacent.Push(0);
        int provinces = 0;
        int curNdex = 0;

        while (curNdex < isConnected.Length)
        {
            while (adjacent.Count > 0)
            {
                curNdex = adjacent.Pop();
                visited.Add(curNdex);
                for (int j = 0; j < isConnected.Length; j++)
                {
                    if (!visited.Contains(j) && isConnected[curNdex][j] == 1)
                    {
                        adjacent.Push(j);
                    }
                }
            }

            provinces++;

            int i = 0;
            while (visited.Contains(i))
            {
                i++;
            }

            curNdex = i;
            adjacent.Push(curNdex);

        }






        return provinces;
    }
}
