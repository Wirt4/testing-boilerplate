
namespace LeetCodeSolutions;
public class TotalCostToHireKWorkersSolution
{
    private PriorityQueue<int, int> CreateLeftSet(int[] costs, ref int i, int n)
    {
        PriorityQueue<int, int> leftSet = new();

        while (i < n)
        {
            leftSet.Enqueue(costs[i], costs[i]);
            i++;
        }

        return leftSet;
    }
    private PriorityQueue<int, int> CreateRightSet(int[] costs, int n, int i, ref int j)
    {
        PriorityQueue<int, int> q = new();
        while (j >= i && j > costs.Length - 1 - n)
        {
            q.Enqueue(costs[j], costs[j]);
            j--;
        }
        return q;
    }

    private int DequeueEnqueueRightSet(int[] costs, int i, ref int j, ref PriorityQueue<int, int> set)
    {
        int ans = set.Dequeue();

        if (i <= j)
        {
            set.Enqueue(costs[j], costs[j]);
            j--;
        }
        return ans;
    }

    private int DequeueEnqueueLeftSet(int[] costs, ref int i, int j, ref PriorityQueue<int, int> set)
    {
        int ans = set.Dequeue();

        if (i <= j)
        {
            set.Enqueue(costs[i], costs[i]);
            i++;
        }
        return ans;
    }


    public long TotalCost(int[] costs, int k, int n)
    {
        int i = 0;
        PriorityQueue<int, int> leftSet = CreateLeftSet(costs, ref i, n);

        int j = costs.Length - 1;
        PriorityQueue<int, int> rightSet = CreateRightSet(costs, n, i, ref j);

        long total = 0;
        for (int m = 0; m < k; m++)
        {
            if (leftSet.Count == 0 && rightSet.Count == 0)
            {
                break;
            }

            if (leftSet.Count == 0 && rightSet.Count > 0)
            {
                total += DequeueEnqueueRightSet(costs, i, ref j, ref rightSet);
                continue;
            }
            if (leftSet.Count > 0 && rightSet.Count == 0)
            {
                total += DequeueEnqueueLeftSet(costs, ref i, j, ref leftSet);
                continue;
            }
            if (leftSet.Count > 0 && rightSet.Count > 0)
            {
                if (leftSet.Peek() <= rightSet.Peek())
                {
                    total += DequeueEnqueueLeftSet(costs, ref i, j, ref leftSet);
                    continue;
                }
                total += DequeueEnqueueRightSet(costs, i, ref j, ref rightSet);
            }
        }

        return total;
    }
}
