
using System.Reflection.Metadata.Ecma335;

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
                total += rightSet.Dequeue();

                if (i <= j)
                {
                    rightSet.Enqueue(costs[j], costs[j]);
                    j--;
                }
                continue;
            }
            if (leftSet.Count > 0 && rightSet.Count == 0)
            {
                total += leftSet.Dequeue();

                if (i <= j)
                {
                    leftSet.Enqueue(costs[i], costs[i]);
                    i++;
                }
                continue;
            }
            if (leftSet.Count > 0 && rightSet.Count > 0)
            {
                if (leftSet.Peek() <= rightSet.Peek())
                {
                    total += leftSet.Dequeue();

                    if (i <= j)
                    {
                        leftSet.Enqueue(costs[i], costs[i]);
                        i++;
                    }
                    continue;
                }

                total += rightSet.Dequeue();
                if (i <= j)
                {
                    rightSet.Enqueue(costs[j], costs[j]);
                    j--;
                }

            }
        }

        return total;
    }
}
