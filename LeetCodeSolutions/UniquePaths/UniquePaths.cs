

namespace LeetCodeSolutions;
public class UniquePathsSolution
{
    public int UniquePaths(int m, int n)
    {
        int UniquePaths = 0;
        Queue<int[]> queue = new();
        queue.Enqueue([1, 1]);
        while (queue.Count > 0)
        {
            int c = queue.Count;
            for (int i = 0; i < c; i++)
            {
                int[] current = queue.Dequeue();
                if (m == current[0] && n == current[1])
                {
                    UniquePaths++;
                }

                if (current[0] < m)
                {
                    queue.Enqueue([current[0] + 1, current[1]]);
                }

                if (current[1] < n)
                {
                    queue.Enqueue([current[0], current[1] + 1]);
                }
            }
        }

        return UniquePaths;
    }
}
